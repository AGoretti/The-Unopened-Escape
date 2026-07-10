using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClickLogger : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    void Start()
    {
        Debug.Log("Script iniciado");
    }

    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        Debug.Log("Objeto clicado: " + gameObject.name);
    }
}