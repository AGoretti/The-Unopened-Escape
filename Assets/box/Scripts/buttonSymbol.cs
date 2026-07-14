using UnityEngine;

public class SymbolButton : MonoBehaviour
{
    public SymbolPuzzle puzzle;
    public int indice;

    public void OnPressed()
    {
        puzzle.PressSymbol(
            puzzle.puzzleManager.simbolosSorteados[indice]
        );
    }
}