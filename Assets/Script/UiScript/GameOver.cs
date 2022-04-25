using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    //Fonction
    public SceenFader sceneFader;
    public string menuSceneName  = "Menu";


    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }


    public void Menu()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(menuSceneName); 
    }
}
