using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    public NumeroAleatorio numeroAleatorio;

    public LeverController lever1;
    public LeverController lever2;
    public LeverController lever3;
    public LeverController lever4;

    [Header("LED")]
    public Renderer ledRenderer;
    public Material ledApagado;
    public Material ledVerde;

    public void ValidatePuzzle()
    {
        int id = numeroAleatorio.ID;

        LeverController.LeverPosition expected1;
        LeverController.LeverPosition expected2;
        LeverController.LeverPosition expected3;
        LeverController.LeverPosition expected4;

        //-----------------------------------
        // PRIMEIRA ALAVANCA
        //-----------------------------------

        if (id % 2 == 0)
            expected1 = LeverController.LeverPosition.Up;
        else
            expected1 = LeverController.LeverPosition.Down;

        //-----------------------------------
        // SEGUNDA
        //-----------------------------------

        if (id.ToString().Contains("8"))
            expected2 = LeverController.LeverPosition.Middle;
        else
            expected2 = LeverController.LeverPosition.Up; // escolha uma posição padrão

        //-----------------------------------
        // TERCEIRA
        //-----------------------------------

        expected3 =
            expected1 == LeverController.LeverPosition.Up ?
            LeverController.LeverPosition.Down :
            LeverController.LeverPosition.Up;

        //-----------------------------------
        // QUARTA
        //-----------------------------------

        expected4 = LeverController.LeverPosition.Up;

        foreach(char c in id.ToString())
        {
            if ((c - '0') > 6)
            {
                expected4 = LeverController.LeverPosition.Down;
                break;
            }
        }

        Debug.Log("Esperado:");
        Debug.Log(expected1);
        Debug.Log(expected2);
        Debug.Log(expected3);
        Debug.Log(expected4);

        Debug.Log("Atual:");
        Debug.Log(lever1.CurrentPosition);
        Debug.Log(lever2.CurrentPosition);
        Debug.Log(lever3.CurrentPosition);
        Debug.Log(lever4.CurrentPosition);

        //-----------------------------------
        // COMPARAÇÃO
        //-----------------------------------

        bool solved =
            lever1.CurrentPosition == expected1 &&
            lever2.CurrentPosition == expected2 &&
            lever3.CurrentPosition == expected3 &&
            lever4.CurrentPosition == expected4;

        if(solved)
        {
            Debug.Log("Puzzle resolvido!");

            ledRenderer.material = ledVerde;
        }
        else
        {
            Debug.Log("Configuração incorreta.");
        }
    }
}