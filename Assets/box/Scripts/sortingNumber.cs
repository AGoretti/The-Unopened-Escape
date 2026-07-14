using TMPro;
using UnityEngine;

public class NumeroAleatorio : MonoBehaviour
{
    public TMP_Text texto;

    public int minimo = 0;
    public int maximo = 100;

    public int ID { get; private set; }

    void Start()
    {
        ID = Random.Range(minimo, maximo + 1);
        texto.text = ID.ToString();
    }
}