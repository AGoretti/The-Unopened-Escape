using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ClickLogger : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField]
    private XRSimpleInteractable buttonInteractable;

    [Tooltip("Objeto visual que será movimentado. Pode ser o próprio botão.")]
    [SerializeField]
    private Transform movingPart;

    [Header("Puzzle de Símbolos (opcional)")]
    [SerializeField]
    private SymbolPuzzle symbolPuzzle;

    [SerializeField]
    private int simboloIndice;

    [Header("Entrada do Trigger")]
    [SerializeField]
    private InputActionReference leftTriggerAction;

    [SerializeField]
    private InputActionReference rightTriggerAction;

    [Header("Movimento")]
    [Tooltip("Eixo LOCAL do botão. Cilindros normalmente usam Y.")]
    [SerializeField]
    private Vector3 localPressAxis = new Vector3(0f, -1f, 0f);

    [SerializeField]
    private float pressDepth = 0.01f;

    [SerializeField]
    private float pressDuration = 0.15f;

    [Header("Evento")]
    [SerializeField]
    private UnityEvent onButtonClicked;

    private Vector3 originalLocalPosition;
    private bool isHovered;
    private bool isPressing;

    private void Awake()
    {
        if (buttonInteractable == null)
            buttonInteractable = GetComponent<XRSimpleInteractable>();

        if (movingPart == null)
            movingPart = transform;

        originalLocalPosition = movingPart.localPosition;
    }

    private void OnEnable()
    {
        if (buttonInteractable == null)
        {
            Debug.LogError(
                "ClickLogger: XR Simple Interactable não configurado.",
                this
            );

            return;
        }

        buttonInteractable.hoverEntered.AddListener(OnHoverEntered);
        buttonInteractable.hoverExited.AddListener(OnHoverExited);

        SubscribeAction(leftTriggerAction);
        SubscribeAction(rightTriggerAction);
    }

    private void OnDisable()
    {
        if (buttonInteractable != null)
        {
            buttonInteractable.hoverEntered.RemoveListener(OnHoverEntered);
            buttonInteractable.hoverExited.RemoveListener(OnHoverExited);
        }

        UnsubscribeAction(leftTriggerAction);
        UnsubscribeAction(rightTriggerAction);
    }

    private void SubscribeAction(InputActionReference actionReference)
    {
        if (actionReference == null)
            return;

        actionReference.action.performed += OnTriggerPressed;

        if (!actionReference.action.enabled)
            actionReference.action.Enable();
    }

    private void UnsubscribeAction(InputActionReference actionReference)
    {
        if (actionReference == null)
            return;

        actionReference.action.performed -= OnTriggerPressed;
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        isHovered = true;
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        isHovered = false;
    }

    private void OnTriggerPressed(InputAction.CallbackContext context)
    {
        // Só aceita o clique quando o controle ou raio
        // estiver sobre o botão.
        if (!isHovered || isPressing)
            return;

        PressButton();
    }

    private void PressButton()
    {
        Debug.Log($"{gameObject.name} foi pressionado.");

        onButtonClicked?.Invoke();


        // Se esse botão pertence ao puzzle de símbolos
        if(symbolPuzzle != null)
        {
            symbolPuzzle.PressionarSimbolo(simboloIndice);
        }


        StartCoroutine(PressAnimation());
    }

    private IEnumerator PressAnimation()
    {
        isPressing = true;

        float duration = Mathf.Max(pressDuration, 0.01f);
        float halfDuration = duration / 2f;

        /*
         * localPressAxis é o eixo do próprio botão.
         * localRotation converte esse eixo para o espaço do pai,
         * utilizado pelo localPosition.
         */
        Vector3 directionInParentSpace =
            movingPart.localRotation *
            localPressAxis.normalized;

        Vector3 pressedPosition =
            originalLocalPosition +
            directionInParentSpace * pressDepth;

        float time = 0f;

        while (time < halfDuration)
        {
            time += Time.deltaTime;

            movingPart.localPosition = Vector3.Lerp(
                originalLocalPosition,
                pressedPosition,
                time / halfDuration
            );

            yield return null;
        }

        movingPart.localPosition = pressedPosition;

        time = 0f;

        while (time < halfDuration)
        {
            time += Time.deltaTime;

            movingPart.localPosition = Vector3.Lerp(
                pressedPosition,
                originalLocalPosition,
                time / halfDuration
            );

            yield return null;
        }

        movingPart.localPosition = originalLocalPosition;
        isPressing = false;
    }
}