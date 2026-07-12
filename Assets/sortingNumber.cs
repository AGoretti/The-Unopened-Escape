using TMPro;
using UnityEngine;

public class NumeroAleatorio : MonoBehaviour
{
    public TMP_Text texto;

    public int minimo = 0;
    public int maximo = 100;

    void Start()
    {
        int numero = Random.Range(minimo, maximo + 1);
        texto.text = numero.ToString();
    }
}