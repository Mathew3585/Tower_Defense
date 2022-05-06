using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Fonction
    [Header("PauseUi")]
    public GameObject ui;
    [Space(10)]
    [Header("SceenFader")]
    public SceenFader sceneFader;
    [Space(10)]
    [Header("Nom du Menu")]
    public string menuSceneName;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    //Recherger la scene
    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    //Charger le menu
    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
