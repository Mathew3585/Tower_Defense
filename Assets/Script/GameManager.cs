using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    [Header("Ui de Game Over")]
    public GameObject GameOverUi;


    private void Start()
    {
        gameIsOver = false; 
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
        GameOverUi.SetActive(true);
        
    }
}
