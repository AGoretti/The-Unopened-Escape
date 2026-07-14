using System.Collections.Generic;
using UnityEngine;

public class SoundPuzzle : MonoBehaviour
{
    public SoundPuzzleManager puzzleManager;


    [Header("LED")]
    public Renderer ledRenderer;
    public Material ledVerde;
    public Material ledVermelho;

    [Header("Áudios de Feedback")]
    public AudioSource feedbackAudioSource;

    public AudioClip audioSucesso;
    public AudioClip audioErro;

    private List<Simbolo> tentativaJogador = new();



    public void PressionarQuad(int indice)
    {
        // Descobre qual símbolo está nesse quad
        Simbolo simbolo =
            puzzleManager.simbolosDosQuads[indice];


        tentativaJogador.Add(simbolo);


        Debug.Log("Jogador apertou: " + simbolo);


        // Ainda não completou a sequência
        if(tentativaJogador.Count < puzzleManager.ordemCorreta.Count)
            return;


        Verificar();
    }



    void Verificar()
    {
        bool correto = true;


        for(int i = 0; i < puzzleManager.ordemCorreta.Count; i++)
        {
            if(tentativaJogador[i] != puzzleManager.ordemCorreta[i])
            {
                correto = false;
                break;
            }
        }



        if(correto)
        {
            Debug.Log("PUZZLE DE SOM RESOLVIDO!");

            if(ledRenderer != null)
                ledRenderer.material = ledVerde;


            if(feedbackAudioSource != null && audioSucesso != null)
            {
                feedbackAudioSource.PlayOneShot(audioSucesso);
            }
        }
        else
        {
            Debug.Log("Sequência errada!");

            if(ledRenderer != null)
                ledRenderer.material = ledVermelho;


            if(feedbackAudioSource != null && audioErro != null)
            {
                feedbackAudioSource.PlayOneShot(audioErro);
            }


            tentativaJogador.Clear();
        }
    }
}