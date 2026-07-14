using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public MeshRenderer[] simbolos;
    public Material[] materiais;

    public Simbolo[] simbolosSorteados;

    void Start()
    {
        List<int> indices = new List<int>();

        for (int i = 0; i < materiais.Length; i++)
            indices.Add(i);

        simbolosSorteados = new Simbolo[simbolos.Length];

        for (int i = 0; i < simbolos.Length; i++)
        {
            int sorteado = Random.Range(0, indices.Count);

            int indiceMaterial = indices[sorteado];

            simbolos[i].material = materiais[indiceMaterial];

            simbolosSorteados[i] = (Simbolo)indiceMaterial;

            indices.RemoveAt(sorteado);
        }
    }
}