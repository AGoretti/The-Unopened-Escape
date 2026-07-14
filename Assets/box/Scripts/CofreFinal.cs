using UnityEngine;
using UnityEngine.SceneManagement;

public class CofreFinal : MonoBehaviour
{
    [Header("Os 3 LEDs dos puzzles")]
    public Renderer ledPuzzle1;
    public Renderer ledPuzzle2;
    public Renderer ledPuzzle3;


    [Header("Material verde")]
    public Material materialVerde;


    [Header("Tela de Vitória")]
    public GameObject canvasVitoria;


    [Header("Som de Vitória")]
    public AudioSource audioSource;
    public AudioClip somVitoria;


    private bool venceu = false;


    void Start()
    {
        if(canvasVitoria != null)
            canvasVitoria.SetActive(false);
    }


    void Update()
    {
        if(venceu)
            return;


        bool led1 = ledPuzzle1.material == materialVerde;
        bool led2 = ledPuzzle2.material == materialVerde;
        bool led3 = ledPuzzle3.material == materialVerde;


        if(led1 && led2 && led3)
        {
            Vitoria();
        }
    }



    void Vitoria()
    {
        venceu = true;


        Debug.Log("TODOS OS PUZZLES RESOLVIDOS!");


        // Abre tela de vitória
        if(canvasVitoria != null)
            canvasVitoria.SetActive(true);



        // Toca som de vitória
        if(audioSource != null && somVitoria != null)
        {
            audioSource.PlayOneShot(somVitoria);
        }



        // Congela o jogo
        Time.timeScale = 0f;
    }



    public void VoltarMenu()
    {
        // Descongela antes de trocar de cena
        Time.timeScale = 1f;


        SceneManager.LoadScene("Menu");
    }
}