using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LeverController : MonoBehaviour
{
    [Header("Som da alavanca")]

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip somAlavanca;

    [Header("Referências")]

    [Tooltip("XR Simple Interactable do Handle, filho deste Pivot.")]
    [SerializeField]
    private XRSimpleInteractable leverInteractable;

    [Header("Limites da rotação local X")]

    [Range(-90f, 90f)]
    [SerializeField]
    private float minAngle = -30f;

    [Range(-90f, 90f)]
    [SerializeField]
    private float maxAngle = 30f;

    [Header("Suavização")]

    [Tooltip("Tempo utilizado para suavizar o movimento.")]
    [Min(0.001f)]
    [SerializeField]
    private float smoothTime = 0.06f;

    [Header("Eventos")]

    [SerializeField]
    private UnityEvent onLeverUp;

    [SerializeField]
    private UnityEvent onLeverDown;

    public enum LeverPosition
    {
        Down,
        Middle,
        Up
    }

    public LeverPosition CurrentPosition
    {
        get;
        private set;
    }

    private IXRSelectInteractor interactor;

    private float pointerAngleAtGrab;
    private float leverAngleAtGrab;
    private float targetAngle;
    private float smoothVelocity;

    private float fixedLocalY;
    private float fixedLocalZ;

    private bool isOn;
    private LeverPosition lastPosition;

    private void Awake()
    {
        /*
         * O Pivot pode ter uma orientação própria por
         * estar localizado em uma face diferente do cubo.
         * Mantemos Y e Z fixos e alteramos somente X.
         */
        Vector3 initialEuler =
            transform.localEulerAngles;

        fixedLocalY = initialEuler.y;
        fixedLocalZ = initialEuler.z;

        float currentAngle =
            GetCurrentLeverAngle();

        targetAngle = Mathf.Clamp(
            currentAngle,
            Mathf.Min(minAngle, maxAngle),
            Mathf.Max(minAngle, maxAngle)
        );

        CurrentPosition =
            CalculatePosition(currentAngle);

        lastPosition = CurrentPosition;

        float middleAngle =
            (minAngle + maxAngle) / 2f;

        isOn = currentAngle > middleAngle;
    }

    private void OnEnable()
    {
        if (leverInteractable == null)
        {
            Debug.LogError(
                "LeverController: arraste o XR Simple " +
                "Interactable do Handle.",
                this
            );

            return;
        }

        leverInteractable.selectEntered.AddListener(
            OnGrab
        );

        leverInteractable.selectExited.AddListener(
            OnRelease
        );
    }

    private void OnDisable()
    {
        if (leverInteractable == null)
            return;

        leverInteractable.selectEntered.RemoveListener(
            OnGrab
        );

        leverInteractable.selectExited.RemoveListener(
            OnRelease
        );
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        interactor = args.interactorObject;

        leverAngleAtGrab =
            GetCurrentLeverAngle();

        targetAngle = leverAngleAtGrab;
        smoothVelocity = 0f;

        if (!TryGetPointerAngle(out pointerAngleAtGrab))
        {
            interactor = null;

            Debug.LogWarning(
                "LeverController: não foi possível " +
                "obter a posição do interactor.",
                this
            );
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (args.interactorObject != interactor)
            return;

        interactor = null;
        smoothVelocity = 0f;
    }

    private void Update()
    {
        if (interactor != null &&
            TryGetPointerAngle(out float pointerAngle))
        {
            /*
             * Aplica apenas a diferença movimentada depois
             * do Grab. Isso evita o pulo inicial.
             */
            float pointerDelta =
                Mathf.DeltaAngle(
                    pointerAngleAtGrab,
                    pointerAngle
                );

            targetAngle =
                leverAngleAtGrab + pointerDelta;

            targetAngle = Mathf.Clamp(
                targetAngle,
                Mathf.Min(minAngle, maxAngle),
                Mathf.Max(minAngle, maxAngle)
            );
        }

        float currentAngle =
            GetCurrentLeverAngle();

        float newAngle =
            Mathf.SmoothDampAngle(
                currentAngle,
                targetAngle,
                ref smoothVelocity,
                smoothTime
            );

        newAngle = Mathf.Clamp(
            newAngle,
            Mathf.Min(minAngle, maxAngle),
            Mathf.Max(minAngle, maxAngle)
        );

        transform.localRotation =
            Quaternion.Euler(
                newAngle,
                fixedLocalY,
                fixedLocalZ
            );

        UpdateLeverState(newAngle);
    }

    private bool TryGetPointerAngle(
        out float angle
    )
    {
        angle = 0f;

        if (interactor == null ||
            leverInteractable == null)
        {
            return false;
        }

        Transform attachTransform =
            interactor.GetAttachTransform(
                leverInteractable
            );

        if (attachTransform == null)
            return false;

        /*
         * A direção parte do Pivot, e não do Handle.
         */
        Vector3 worldDirection =
            attachTransform.position -
            transform.position;

        Vector3 localDirection =
            transform.parent != null
                ? transform.parent
                    .InverseTransformDirection(
                        worldDirection
                    )
                : worldDirection;

        /*
         * A alavanca gira no plano local Y/Z,
         * ao redor do eixo local X.
         */
        localDirection.x = 0f;

        if (localDirection.sqrMagnitude < 0.000001f)
            return false;

        localDirection.Normalize();

        angle =
            Mathf.Atan2(
                localDirection.z,
                localDirection.y
            ) * Mathf.Rad2Deg;

        return true;
    }

    private float GetCurrentLeverAngle()
    {
        return Mathf.DeltaAngle(
            0f,
            transform.localEulerAngles.x
        );
    }

    private void UpdateLeverState(float angle)
    {
        float middleAngle =
            (minAngle + maxAngle) / 2f;

        bool newIsOn =
            angle > middleAngle;

        if (newIsOn != isOn)
        {
            isOn = newIsOn;

            if (isOn)
                onLeverUp?.Invoke();
            else
                onLeverDown?.Invoke();
        }

        LeverPosition newPosition =
            CalculatePosition(angle);

        if (newPosition != lastPosition)
        {
            PlayLeverSound();
            lastPosition = newPosition;
        }

        CurrentPosition = newPosition;
    }

    private LeverPosition CalculatePosition(
        float angle
    )
    {
        const float middleTolerance = 10f;

        if (angle > middleTolerance)
            return LeverPosition.Up;

        if (angle < -middleTolerance)
            return LeverPosition.Down;

        return LeverPosition.Middle;
    }

    private void PlayLeverSound()
    {
        if (audioSource != null &&
            somAlavanca != null)
        {
            audioSource.PlayOneShot(
                somAlavanca
            );
        }
    }
}