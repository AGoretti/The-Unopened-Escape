using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SymbolPuzzle : MonoBehaviour
{
    public PuzzleManager puzzleManager;

    List<Simbolo> ordemCorreta = new();
    List<Simbolo> sequenciaJogador = new();

    Dictionary<Simbolo, int> pontas = new Dictionary<Simbolo, int>()
    {
        {Simbolo.Espiral,0},
        {Simbolo.Vela,1},
        {Simbolo.Lua,2},
        {Simbolo.Olho,3},
        {Simbolo.Triangulo,4},
        {Simbolo.Chave,5},
        {Simbolo.Rato,6},
        {Simbolo.Mao,7}
    };

    void Start()
    {
        ordemCorreta = puzzleManager.simbolosSorteados.ToList();

        //-------------------------
        // Vela antes do Olho
        //-------------------------

        if (ordemCorreta.Contains(Simbolo.Vela) &&
            ordemCorreta.Contains(Simbolo.Olho))
        {
            ordemCorreta.Remove(Simbolo.Vela);
            ordemCorreta.Insert(0, Simbolo.Vela);
        }

        //-------------------------
        // Lua antes da Chave
        //-------------------------

        int lua = ordemCorreta.IndexOf(Simbolo.Lua);
        int chave = ordemCorreta.IndexOf(Simbolo.Chave);

        if (lua != -1 && chave != -1 && lua > chave)
        {
            ordemCorreta.Remove(Simbolo.Lua);

            chave = ordemCorreta.IndexOf(Simbolo.Chave);

            ordemCorreta.Insert(chave, Simbolo.Lua);
        }

        //-------------------------
        // Rato nunca por último
        //-------------------------

        if (ordemCorreta.Last() == Simbolo.Rato)
        {
            ordemCorreta.Remove(Simbolo.Rato);

            ordemCorreta.Insert(ordemCorreta.Count - 1, Simbolo.Rato);
        }

        //-------------------------
        // Mais pontas por último
        //-------------------------

        Simbolo ultimo = ordemCorreta
            .OrderBy(s => pontas[s])
            .Last();

        ordemCorreta.Remove(ultimo);
        ordemCorreta.Add(ultimo);

        Debug.Log("Ordem correta:");

        foreach (Simbolo s in ordemCorreta)
            Debug.Log(s);
    }

    public void PressSymbol(Simbolo simbolo)
    {
        sequenciaJogador.Add(simbolo);

        if (sequenciaJogador.Count == ordemCorreta.Count)
        {
            bool correto = sequenciaJogador.SequenceEqual(ordemCorreta);

            if (correto)
            {
                Debug.Log("Puzzle resolvido!");
            }
            else
            {
                Debug.Log("Sequência incorreta!");
            }

            sequenciaJogador.Clear();
        }
    }
}