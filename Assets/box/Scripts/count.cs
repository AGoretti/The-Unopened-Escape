using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float tempo = 60f;
    public TextMeshPro textoTempo;
    public GameObject gameOverPanel;
    public AudioSource audioTimer;
    public AudioSource audioGameOver;
    public AudioClip somTick;
    public AudioClip somGameOver;

    private int ultimoSegundo = -1;

    bool acabou = false;

    void Start()
    {
        Time.timeScale = 1;
        textoTempo.color = Color.white;
    }


    void Update()
    {
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;
        }

        int minutos = Mathf.FloorToInt(tempo / 60);
        int segundos = Mathf.FloorToInt(tempo % 60);

        textoTempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");

        if (tempo <= 60)
        {
            textoTempo.color = Color.red;

            int segundoAtual = Mathf.CeilToInt(tempo);

            if (segundoAtual != ultimoSegundo)
            {
                ultimoSegundo = segundoAtual;

                if (tempo > 0)
                {
                    audioTimer.PlayOneShot(somTick);
                }
            }
        }

        if (tempo <= 0 && !acabou)
        {
            GameOver();
        }
    }

    public void VoltarMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    void GameOver()
    {
        acabou = true;

        gameOverPanel.SetActive(true);

        audioGameOver.PlayOneShot(somGameOver);

        Time.timeScale = 0;
    }
}