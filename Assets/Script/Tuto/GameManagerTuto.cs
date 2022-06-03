using UnityEngine;

[DefaultExecutionOrder(-50)]
public class GameManagerTuto : MonoBehaviour
{
    public static GameManagerTuto instance;

    public static bool gameIsOver;
    [Header("Ui de Game Over")]
    public GameObject GameOverUi;
    [Space(5)]
    public AudioClip AudioGameOver;
    AudioSource audioSource_GameOver;
    [Header("Fader")]
    public SceenFader SceneFader;
    [Header("Ui de victoire")]
    [Space(5)]
    AudioSource audioSource_WinLevel;
    Ennemy ennemy;

    public GameObject ImageDégat;
    public GameObject ImageLowLife;
    public Transform camera;


    private void Start()
    { 
        gameIsOver = false;
        audioSource_GameOver = new GameObject("AudioSource_GameOver").AddComponent<AudioSource>();
        audioSource_WinLevel = new GameObject("AudioSource_WinLevel").AddComponent<AudioSource>();

        instance = this;
    }


    void Update()
    {
        if (gameIsOver)
        {
            return;
        }


        if(Player_Stat.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        audioSource_GameOver.PlayOneShot(AudioGameOver);
        GameOverUi.SetActive(true);
        
    }
}
