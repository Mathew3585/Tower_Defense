using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    void Update()
    {
        if (gameEnded)
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
        gameEnded = true;
        Debug.Log("Game Over!");
    }
}
