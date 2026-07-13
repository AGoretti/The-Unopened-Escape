using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public MeshRenderer[] simbolos;      // Os Quads dos botões
    public Material[] materiais;         // Todos os materiais dos símbolos

    void Start()
    {
        // Embaralha os materiais
        for (int i = 0; i < materiais.Length; i++)
        {
            Material temp = materiais[i];
            int random = Random.Range(i, materiais.Length);

            materiais[i] = materiais[random];
            materiais[random] = temp;
        }

        // Coloca um símbolo diferente em cada botão
        for (int i = 0; i < simbolos.Length; i++)
        {
            simbolos[i].material = materiais[i];
        }
    }
}