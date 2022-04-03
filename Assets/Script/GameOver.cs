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
    }


    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName); 
    }
}
