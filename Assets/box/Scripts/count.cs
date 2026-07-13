using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text textoTempo;

    public float tempo = 300f; // 5 minutos

    void Update()
    {
        tempo -= Time.deltaTime;

        int minutos = Mathf.FloorToInt(tempo / 60);
        int segundos = Mathf.FloorToInt(tempo % 60);

        textoTempo.text = $"{minutos:00}:{segundos:00}";
    }
}