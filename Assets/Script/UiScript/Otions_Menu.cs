using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Otions_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public string LevelToLoad = "Map";
    public SceenFader sceenFader;
    public void Playgame()
    {
        sceenFader.FadeTo(LevelToLoad);
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
}
