using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LeverController : MonoBehaviour
{
    [Header("Referências")]
    [Tooltip("O XR Simple Interactable do objeto 'lever' (filho deste pivot)")]
    public XRSimpleInteractable leverInteractable;

    [Header("Limites de Rotação (eixo X)")]
    [Range(-90f, 90f)] public float minAngle = -30f;
    [Range(-90f, 90f)] public float maxAngle = 30f;

    [Header("Eventos (opcional)")]
    public UnityEvent onLeverUp;
    public UnityEvent onLeverDown;

    IXRSelectInteractor interactor;
    bool isOn;

    public enum LeverPosition
    {
        Down,
        Middle,
        Up
    }

    public LeverPosition CurrentPosition { get; private set; }

    void OnEnable()
    {
        if (leverInteractable == null)
        {
            Debug.LogError("LeverController: arraste o XR Simple Interactable do 'lever' aqui!");
            return;
        }
        leverInteractable.selectEntered.AddListener(OnGrab);
        leverInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        if (leverInteractable == null) return;
        leverInteractable.selectEntered.RemoveListener(OnGrab);
        leverInteractable.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args) => interactor = args.interactorObject;
    void OnRelease(SelectExitEventArgs args) => interactor = null;

    void Update()
{
    // Só movimenta a alavanca enquanto ela está sendo segurada
    if (interactor != null)
    {
        Vector3 direction = interactor.GetAttachTransform(leverInteractable).position - transform.position;
        direction = transform.parent.InverseTransformDirection(direction);
        direction.x = 0f;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.z, direction.y) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, Mathf.Min(minAngle, maxAngle), Mathf.Max(minAngle, maxAngle));

        transform.localRotation = Quaternion.Euler(angle, 0f, 0f);

        bool newIsOn = angle > (minAngle + maxAngle) / 2f;
        if (newIsOn != isOn)
        {
            isOn = newIsOn;
            if (isOn) onLeverUp?.Invoke();
            else onLeverDown?.Invoke();
        }
    }

    // Descobre a posição atual da alavanca olhando a rotação dela
    float angleAtual = transform.localEulerAngles.x;

    if (angleAtual > 180f)
        angleAtual -= 360f;

    float middleTolerance = 10f;

    if (angleAtual > middleTolerance)
        CurrentPosition = LeverPosition.Up;
    else if (angleAtual < -middleTolerance)
        CurrentPosition = LeverPosition.Down;
    else
        CurrentPosition = LeverPosition.Middle;
}
}