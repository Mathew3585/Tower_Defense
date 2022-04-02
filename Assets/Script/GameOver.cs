using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    //Fonction
    [Header("Text Rounds Survécus")]
    public TMP_Text roundsText;


    void OnEnable()
    {
        roundsText.text = Player_Stat.Rounds.ToString();
    }


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
