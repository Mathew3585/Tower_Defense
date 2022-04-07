using UnityEngine;
using UnityEngine.SceneManagement;
public class CompletLevel : MonoBehaviour
{
    //Fonction


    public SceenFader sceneFader;
    public string menuSceneName = "Menu";
    [Header("Nom de la Map a charger apres la victoire")]
    public string nextLevel = "Level02";
    [Header("Nombre de Map a débloquer")]
    public int levelToUnlock = 2;

    public void OnEnable()
    {
        if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(nextLevel);

    }
     

    public void Menu()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(menuSceneName);
    }
}
