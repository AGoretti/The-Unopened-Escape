using UnityEngine;

public class BotaoAnimacao : MonoBehaviour
{
    Vector3 escalaInicial;

    void Start()
    {
        escalaInicial = transform.localScale;
    }

    public void Apertou()
    {
        transform.localScale = escalaInicial * 0.9f;
    }
}