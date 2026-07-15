using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CubeDragRotator : MonoBehaviour
{
    [Header("Referências")]

    [Tooltip("XR Simple Interactable localizado no Cube_COL.")]
    [SerializeField]
    private XRSimpleInteractable cubeInteractable;

    [Tooltip("Main Camera localizada dentro do XR Origin.")]
    [SerializeField]
    private Transform referenceCamera;

    [Tooltip("Objeto vazio localizado exatamente no centro visual do cubo.")]
    [SerializeField]
    private Transform pivotOverride;

    [Header("Entrada do gatilho")]

    [SerializeField]
    private InputActionReference leftTriggerAction;

    [SerializeField]
    private InputActionReference rightTriggerAction;

    [Header("Arrasto para trocar de face")]

    [Tooltip("Distância necessária para disparar uma rotação.")]
    [SerializeField]
    private float dragThreshold = 0.02f;

    [SerializeField]
    private bool invertHorizontal;

    [SerializeField]
    private bool invertVertical;

    [Header("Joystick opcional")]

    [Tooltip("Deixe vazio para desativar o joystick esquerdo.")]
    [SerializeField]
    private InputActionReference leftJoystickAction;

    [Tooltip("Deixe vazio para desativar o joystick direito.")]
    [SerializeField]
    private InputActionReference rightJoystickAction;

    [SerializeField]
    private float joystickThreshold = 0.6f;

    [SerializeField]
    private bool invertRoll;

    [Header("Animação")]

    [Tooltip("Duração da animação de 90 graus.")]
    [SerializeField]
    private float snapDuration = 0.15f;

    private const float SnapAngle = 90f;

    private static readonly Vector3[] WorldHorizontalAxes =
    {
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    private bool isHovered;
    private bool isDragging;
    private bool isSnapping;
    private bool consumedThisDrag;
    private bool consumedRollThisHold;

    private IXRInteractor hoveringInteractor;
    private InputAction activeTriggerAction;

    private Transform dragRayOrigin;
    private Plane dragPlane;

    private Vector3 dragStartPosition;
    private Vector3 dragCameraRight;
    private Vector3 dragCameraUp;

    private void Awake()
    {
        /*
         * O preenchimento automático só funciona se o
         * XR Simple Interactable estiver no mesmo objeto.
         *
         * Como recomendamos colocá-lo no Cube_COL,
         * normalmente será necessário preencher o campo
         * manualmente no Inspector.
         */
        if (cubeInteractable == null)
            cubeInteractable = GetComponent<XRSimpleInteractable>();

        if (referenceCamera == null && Camera.main != null)
            referenceCamera = Camera.main.transform;
    }

    private void OnEnable()
    {
        if (cubeInteractable == null)
        {
            Debug.LogError(
                "CubeDragRotator: configure o XR Simple Interactable do Cube_COL.",
                this
            );

            return;
        }

        cubeInteractable.hoverEntered.AddListener(OnHoverEntered);
        cubeInteractable.hoverExited.AddListener(OnHoverExited);

        SubscribeAction(leftTriggerAction);
        SubscribeAction(rightTriggerAction);
    }

    private void OnDisable()
    {
        if (cubeInteractable != null)
        {
            cubeInteractable.hoverEntered.RemoveListener(OnHoverEntered);
            cubeInteractable.hoverExited.RemoveListener(OnHoverExited);
        }

        UnsubscribeAction(leftTriggerAction);
        UnsubscribeAction(rightTriggerAction);

        CancelDrag();
    }

    private void SubscribeAction(
        InputActionReference actionReference
    )
    {
        if (actionReference == null)
            return;

        actionReference.action.performed += OnTriggerPressed;
        actionReference.action.canceled += OnTriggerReleased;

        if (!actionReference.action.enabled)
            actionReference.action.Enable();
    }

    private void UnsubscribeAction(
        InputActionReference actionReference
    )
    {
        if (actionReference == null)
            return;

        actionReference.action.performed -= OnTriggerPressed;
        actionReference.action.canceled -= OnTriggerReleased;
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        /*
         * Se o mesmo controle voltar para o collider
         * durante o arrasto, registra novamente o hover.
         */
        if (isDragging)
        {
            if (args.interactorObject == hoveringInteractor)
                isHovered = true;

            return;
        }

        isHovered = true;
        hoveringInteractor = args.interactorObject;

        Debug.Log(
            $"HOVER NA CAIXA | Interactor: " +
            $"{args.interactorObject.transform.name}",
            this
        );
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        /*
         * Ignora a saída de um controle diferente
         * daquele que estamos utilizando.
         */
        if (args.interactorObject != hoveringInteractor)
            return;

        isHovered = false;

        /*
         * Não cancela o arrasto quando a mira sai do
         * collider. O arrasto termina somente quando
         * o gatilho ativo é solto.
         */
        if (!isDragging)
            hoveringInteractor = null;
    }

    private void OnTriggerPressed(
        InputAction.CallbackContext context
    )
    {
        if (!isHovered ||
            hoveringInteractor == null ||
            isSnapping ||
            isDragging)
        {
            return;
        }

        activeTriggerAction = context.action;

        consumedThisDrag = false;
        consumedRollThisHold = false;

        dragCameraRight =
            referenceCamera != null
                ? referenceCamera.right
                : Vector3.right;

        dragCameraUp =
            referenceCamera != null
                ? referenceCamera.up
                : Vector3.up;

        /*
         * Se o interactor fornece um raio, calcula o
         * arrasto em um plano invisível na frente do cubo.
         *
         * Isso permite arrastar apenas apontando o controle,
         * sem precisar deslocar fisicamente o controle
         * vários centímetros para o lado.
         */
        if (hoveringInteractor is IXRRayProvider rayProvider)
        {
            dragRayOrigin =
                rayProvider.GetOrCreateRayOrigin();

            Vector3 pivotPoint =
                pivotOverride != null
                    ? pivotOverride.position
                    : transform.position;

            Vector3 planeNormal =
                referenceCamera != null
                    ? referenceCamera.forward
                    : transform.forward;

            dragPlane = new Plane(
                planeNormal,
                pivotPoint
            );
        }
        else
        {
            dragRayOrigin = null;
        }

        if (!TryGetDragPosition(out dragStartPosition))
        {
            Debug.LogWarning(
                "CubeDragRotator: não foi possível obter " +
                "a posição inicial do arrasto.",
                this
            );

            CancelDrag();
            return;
        }

        isDragging = true;

        Debug.Log(
            $"ARRASTO INICIADO | Gatilho: " +
            $"{context.action.name}",
            this
        );
    }

    private void OnTriggerReleased(
        InputAction.CallbackContext context
    )
    {
        /*
         * Impede que soltar o gatilho direito cancele
         * um arrasto iniciado pelo esquerdo, e vice-versa.
         */
        if (activeTriggerAction != null &&
            context.action != activeTriggerAction)
        {
            return;
        }

        CancelDrag();
    }

    private void CancelDrag()
    {
        isDragging = false;
        consumedThisDrag = false;
        consumedRollThisHold = false;

        activeTriggerAction = null;
        dragRayOrigin = null;

        if (!isHovered)
            hoveringInteractor = null;
    }

    private void Update()
    {
        if (isSnapping ||
            !isDragging ||
            hoveringInteractor == null)
        {
            return;
        }

        if (!consumedThisDrag)
            CheckDirectionalDrag();

        /*
         * O joystick só funcionará se alguma referência
         * tiver sido configurada no Inspector.
         */
        if (!isSnapping && !consumedRollThisHold)
            CheckJoystickRoll();
    }

    private void CheckDirectionalDrag()
    {
        if (!TryGetDragPosition(out Vector3 currentPosition))
            return;

        Vector3 delta =
            currentPosition - dragStartPosition;

        float horizontalAmount =
            Vector3.Dot(delta, dragCameraRight);

        float verticalAmount =
            Vector3.Dot(delta, dragCameraUp);

        if (invertHorizontal)
            horizontalAmount = -horizontalAmount;

        if (invertVertical)
            verticalAmount = -verticalAmount;

        float horizontalAbsolute =
            Mathf.Abs(horizontalAmount);

        float verticalAbsolute =
            Mathf.Abs(verticalAmount);

        if (Mathf.Max(
                horizontalAbsolute,
                verticalAbsolute
            ) < dragThreshold)
        {
            return;
        }

        consumedThisDrag = true;

        if (horizontalAbsolute >= verticalAbsolute)
        {
            float direction =
                Mathf.Sign(horizontalAmount);

            StartCoroutine(
                SnapRotate(
                    Vector3.up,
                    direction
                )
            );
        }
        else
        {
            float direction =
                -Mathf.Sign(verticalAmount);

            Vector3 rotationAxis =
                SnapToNearestAxis(
                    dragCameraRight,
                    WorldHorizontalAxes
                );

            StartCoroutine(
                SnapRotate(
                    rotationAxis,
                    direction
                )
            );
        }
    }

    private bool TryGetDragPosition(
        out Vector3 position
    )
    {
        position = Vector3.zero;

        /*
         * Interação realizada por raio.
         */
        if (dragRayOrigin != null)
        {
            Ray ray = new Ray(
                dragRayOrigin.position,
                dragRayOrigin.forward
            );

            if (!dragPlane.Raycast(
                    ray,
                    out float distance
                ))
            {
                return false;
            }

            position = ray.GetPoint(distance);
            return true;
        }

        /*
         * Fallback para um interactor que não fornece raio.
         */
        if (hoveringInteractor == null ||
            cubeInteractable == null)
        {
            return false;
        }

        Transform attachTransform =
            hoveringInteractor.GetAttachTransform(
                cubeInteractable
            );

        if (attachTransform == null)
            return false;

        position = attachTransform.position;
        return true;
    }

    private void CheckJoystickRoll()
    {
        Vector2 leftStick =
            leftJoystickAction != null
                ? leftJoystickAction.action
                    .ReadValue<Vector2>()
                : Vector2.zero;

        Vector2 rightStick =
            rightJoystickAction != null
                ? rightJoystickAction.action
                    .ReadValue<Vector2>()
                : Vector2.zero;

        Vector2 stick =
            leftStick.sqrMagnitude >=
            rightStick.sqrMagnitude
                ? leftStick
                : rightStick;

        if (Mathf.Abs(stick.x) < joystickThreshold)
            return;

        consumedRollThisHold = true;

        float direction =
            Mathf.Sign(stick.x);

        if (invertRoll)
            direction = -direction;

        StartCoroutine(
            SnapRotate(
                GetRollAxis(),
                direction
            )
        );
    }

    private Vector3 GetRollAxis()
    {
        Vector3 pivotPoint =
            pivotOverride != null
                ? pivotOverride.position
                : transform.position;

        Vector3 viewDirection =
            referenceCamera != null
                ? (
                    referenceCamera.position -
                    pivotPoint
                ).normalized
                : transform.forward;

        Vector3[] localAxes =
        {
            transform.right,
            -transform.right,
            transform.up,
            -transform.up,
            transform.forward,
            -transform.forward
        };

        return SnapToNearestAxis(
            viewDirection,
            localAxes
        );
    }

    private static Vector3 SnapToNearestAxis(
        Vector3 direction,
        Vector3[] candidateAxes
    )
    {
        Vector3 bestAxis =
            candidateAxes[0];

        float bestDot = -1f;

        foreach (Vector3 axis in candidateAxes)
        {
            float dot =
                Vector3.Dot(
                    direction,
                    axis
                );

            if (dot > bestDot)
            {
                bestDot = dot;
                bestAxis = axis;
            }
        }

        return bestAxis.normalized;
    }

    private IEnumerator SnapRotate(
        Vector3 axis,
        float direction
    )
    {
        isSnapping = true;

        Vector3 pivotPoint =
            pivotOverride != null
                ? pivotOverride.position
                : transform.position;

        Quaternion startRotation =
            transform.rotation;

        Vector3 startPosition =
            transform.position;

        Quaternion rotationOffset =
            Quaternion.AngleAxis(
                SnapAngle * direction,
                axis.normalized
            );

        Vector3 endPosition =
            pivotPoint +
            rotationOffset *
            (startPosition - pivotPoint);

        Quaternion endRotation =
            rotationOffset *
            startRotation;

        float elapsed = 0f;
        float duration =
            Mathf.Max(snapDuration, 0.01f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float progress =
                Mathf.Clamp01(
                    elapsed / duration
                );

            float smoothProgress =
                Mathf.SmoothStep(
                    0f,
                    1f,
                    progress
                );

            transform.position =
                Vector3.Lerp(
                    startPosition,
                    endPosition,
                    smoothProgress
                );

            transform.rotation =
                Quaternion.Slerp(
                    startRotation,
                    endRotation,
                    smoothProgress
                );

            yield return null;
        }

        transform.position = endPosition;
        transform.rotation = endRotation;

        isSnapping = false;
    }
}