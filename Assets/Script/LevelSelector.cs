using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    //Fonction
    public SceenFader sceneFader;
    public Button[] Levelbuttons;


    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1 );

        for (int i = 0;  i < Levelbuttons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                Levelbuttons[i].interactable = false;
            }
        }
    }
    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}
