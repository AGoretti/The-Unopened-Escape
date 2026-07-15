using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SimboloMaterial
{
    public Simbolo simbolo;
    public Material material;
}

public class PuzzleManager : MonoBehaviour
{

    public bool pronto = false;

    [Header("Os 3 quads que exibem os símbolos")]
    public MeshRenderer[] simbolos;

    [Header("Todos os símbolos possíveis")]
    public SimboloMaterial[] simbolosDisponiveis;

    // O SymbolPuzzle vai ler esse vetor
    [HideInInspector]
    public Simbolo[] simbolosSorteados;

    void Start()
    {
        simbolosSorteados = new Simbolo[simbolos.Length];

        List<SimboloMaterial> disponiveis = new List<SimboloMaterial>(simbolosDisponiveis);

        for (int i = 0; i < simbolos.Length; i++)
        {
            int indice = Random.Range(0, disponiveis.Count);

            simbolos[i].material = disponiveis[indice].material;

            simbolosSorteados[i] = disponiveis[indice].simbolo;

            disponiveis.RemoveAt(indice);
        }

        Debug.Log("Símbolos sorteados:");

        foreach (Simbolo s in simbolosSorteados)
        {
            Debug.Log(s);
        }

        pronto = true;
    }
}