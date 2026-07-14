using System.Collections.Generic;
using UnityEngine;

public class SoundPuzzleManager : MonoBehaviour
{
    [Header("Quads dos símbolos")]
    public MeshRenderer[] simbolos;


    [Header("Materiais")]
    public Material luaMaterial;
    public Material chaveMaterial;
    public Material olhoMaterial;


    [Header("Áudios")]
    public AudioSource audioSource;

    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;


    // Guarda qual símbolo está em cada quad
    [HideInInspector]
    public Simbolo[] simbolosDosQuads;


    // Sequência que o jogador precisa fazer
    [HideInInspector]
    public List<Simbolo> ordemCorreta = new();


    private AudioClip audioEscolhido;



    void Start()
    {
        SortearSimbolos();

        SortearAudio();
    }



    void SortearSimbolos()
    {
        simbolosDosQuads = new Simbolo[simbolos.Length];


        List<Simbolo> disponiveis = new List<Simbolo>()
        {
            Simbolo.Lua,
            Simbolo.Chave,
            Simbolo.Olho
        };


        List<Material> materiais = new List<Material>()
        {
            luaMaterial,
            chaveMaterial,
            olhoMaterial
        };


        for(int i = 0; i < simbolos.Length; i++)
        {
            int indice = Random.Range(0, disponiveis.Count);


            simbolosDosQuads[i] = disponiveis[indice];


            simbolos[i].material = materiais[indice];


            disponiveis.RemoveAt(indice);
            materiais.RemoveAt(indice);
        }


        Debug.Log("Distribuição dos quads:");

        for(int i = 0; i < simbolosDosQuads.Length; i++)
        {
            Debug.Log(
                "Quad " + i + " = " + simbolosDosQuads[i]
            );
        }
    }



    void SortearAudio()
    {
        int sorteio = Random.Range(1,4);


        switch(sorteio)
        {
            case 1:

                audioEscolhido = audio1;

                ordemCorreta.Add(Simbolo.Lua);
                ordemCorreta.Add(Simbolo.Chave);
                ordemCorreta.Add(Simbolo.Olho);

                break;



            case 2:

                audioEscolhido = audio2;

                ordemCorreta.Add(Simbolo.Lua);
                ordemCorreta.Add(Simbolo.Olho);
                ordemCorreta.Add(Simbolo.Lua);
                ordemCorreta.Add(Simbolo.Lua);
                ordemCorreta.Add(Simbolo.Chave);

                break;



            case 3:

                audioEscolhido = audio3;

                ordemCorreta.Add(Simbolo.Olho);
                ordemCorreta.Add(Simbolo.Olho);
                ordemCorreta.Add(Simbolo.Chave);

                break;
        }


        Debug.Log("Áudio escolhido: " + sorteio);


        Debug.Log("Sequência correta:");

        foreach(Simbolo s in ordemCorreta)
        {
            Debug.Log(s);
        }
    }



    public void ReproduzirAudio()
    {
        audioSource.clip = audioEscolhido;
        audioSource.Play();
    }
}