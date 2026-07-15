using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ComecarJogo()
    {
        Debug.Log("BOTAO FUNCIONOU!");
        SceneManager.LoadScene("SampleScene");
    }
}