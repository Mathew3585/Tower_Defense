using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    [Header("Ui de Game Over")]
    public GameObject GameOverUi;
    [Space(5)]
    public AudioClip AudioGameOver;
    AudioSource audioSource_GameOver;
    [Header("Fader")]
    public SceenFader SceneFader;
    [Header("Ui de victoire")]
    public GameObject completLevelUI;
    [Space(5)]
    public AudioClip AudioWinLevel;
    AudioSource audioSource_WinLevel;
    Ennemy ennemy;


    private void Start()
    { 
        gameIsOver = false;
        audioSource_GameOver = new GameObject("AudioSource_GameOver").AddComponent<AudioSource>();
        audioSource_WinLevel = new GameObject("AudioSource_WinLevel").AddComponent<AudioSource>();
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

    public void Winlevel()
    {
        Debug.Log("coucou :p");
        gameIsOver = true;
        audioSource_WinLevel.PlayOneShot(AudioWinLevel);
        completLevelUI.SetActive(true);
       
    }

    
}
