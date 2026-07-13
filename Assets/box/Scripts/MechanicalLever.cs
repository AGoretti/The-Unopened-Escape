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
        if (interactor == null) return;

        // Direção do pivot até a mão, no espaço LOCAL do pai (leverBase, que NÃO gira)
        Vector3 direction = interactor.GetAttachTransform(leverInteractable).position - transform.position;
        direction = transform.parent.InverseTransformDirection(direction);
        direction.x = 0f; // ignora profundidade lateral, olha só o plano Y-Z
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
}