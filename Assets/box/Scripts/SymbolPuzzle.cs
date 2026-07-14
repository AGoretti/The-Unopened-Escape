using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class SymbolPuzzle : MonoBehaviour
{
    [Header("Referência")]
    public PuzzleManager puzzleManager;

    [Header("LED (opcional)")]
    public Renderer ledRenderer;
    public Material ledVerde;
    public Material ledVermelho;

    private List<Simbolo> ordemCorreta = new();
    private List<Simbolo> cliquesJogador = new();


    private Dictionary<Simbolo, int> pontas = new Dictionary<Simbolo, int>()
    {
        { Simbolo.Espiral, 0 },
        { Simbolo.Vela, 1 },
        { Simbolo.Lua, 2 },
        { Simbolo.Olho, 3 },
        { Simbolo.Triangulo, 4 },
        { Simbolo.Chave, 5 },
        { Simbolo.Rato, 6 },
        { Simbolo.Mao, 7 }
    };


    void Start()
    {
        StartCoroutine(EsperarPuzzle());
    }


    IEnumerator EsperarPuzzle()
    {
        while (!puzzleManager.pronto)
        {
            yield return null;
        }

        ordemCorreta = puzzleManager.simbolosSorteados.ToList();

        CalcularOrdem();

        Debug.Log("Ordem correta:");

        foreach(Simbolo s in ordemCorreta)
        {
            Debug.Log(s);
        }
    }


    void CalcularOrdem()
    {
        // ================================
        // Regra 1:
        // Vela antes do Olho
        // ================================

        if (ordemCorreta.Contains(Simbolo.Vela) &&
            ordemCorreta.Contains(Simbolo.Olho))
        {
            ordemCorreta.Remove(Simbolo.Vela);
            ordemCorreta.Insert(0, Simbolo.Vela);
        }


        // ================================
        // Regra 2:
        // Lua antes da Chave
        // ================================

        if (ordemCorreta.Contains(Simbolo.Lua) &&
            ordemCorreta.Contains(Simbolo.Chave))
        {
            int posLua = ordemCorreta.IndexOf(Simbolo.Lua);
            int posChave = ordemCorreta.IndexOf(Simbolo.Chave);

            if (posLua > posChave)
            {
                ordemCorreta.Remove(Simbolo.Lua);

                posChave = ordemCorreta.IndexOf(Simbolo.Chave);

                ordemCorreta.Insert(posChave, Simbolo.Lua);
            }
        }


        // ================================
        // Regra 3:
        // Rato nunca pode ser o último
        // ================================

        if (ordemCorreta.Last() == Simbolo.Rato)
        {
            ordemCorreta.Remove(Simbolo.Rato);

            ordemCorreta.Insert(
                ordemCorreta.Count - 1,
                Simbolo.Rato
            );
        }


        // ================================
        // Regra 4:
        // Mais pontas por último
        // ================================

        Simbolo maior =
            ordemCorreta
            .OrderBy(s => pontas[s])
            .Last();


        // Remove e coloca no final
        ordemCorreta.Remove(maior);
        ordemCorreta.Add(maior);
    }


    public void PressionarSimbolo(int indice)
    {
        Simbolo simboloClicado =
            puzzleManager.simbolosSorteados[indice];


        // evita clicar duas vezes no mesmo símbolo
        if (cliquesJogador.Contains(simboloClicado))
            return;


        cliquesJogador.Add(simboloClicado);


        Debug.Log("Clicou: " + simboloClicado);


        if (cliquesJogador.Count == 3)
        {
            VerificarResposta();
        }
    }


    void VerificarResposta()
    {
        Debug.Log("Jogador clicou:");

        foreach (Simbolo s in cliquesJogador)
        {
            Debug.Log(s);
        }


        Debug.Log("Ordem esperada:");

        foreach (Simbolo s in ordemCorreta)
        {
            Debug.Log(s);
        }


        bool correto =
            cliquesJogador.SequenceEqual(ordemCorreta);


        if(correto)
        {
            Debug.Log("PUZZLE RESOLVIDO!");

            if(ledRenderer != null && ledVerde != null)
                ledRenderer.material = ledVerde;
        }
        else
        {
            Debug.Log("Sequência errada!");

            if(ledRenderer != null && ledVermelho != null)
                ledRenderer.material = ledVermelho;

            cliquesJogador.Clear();
        }
    }
}