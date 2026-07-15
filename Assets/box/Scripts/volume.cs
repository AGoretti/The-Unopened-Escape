using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public float volumeAtual = 1f;
    public float passo = 0.1f;

    public void AumentarVolume()
    {
        volumeAtual += passo;
        volumeAtual = Mathf.Clamp(volumeAtual, 0f, 1f);

        AudioListener.volume = volumeAtual;

        Debug.Log("Volume: " + volumeAtual);
    }

    public void DiminuirVolume()
    {
        volumeAtual -= passo;
        volumeAtual = Mathf.Clamp(volumeAtual, 0f, 1f);

        AudioListener.volume = volumeAtual;

        Debug.Log("Volume: " + volumeAtual);
    }
}