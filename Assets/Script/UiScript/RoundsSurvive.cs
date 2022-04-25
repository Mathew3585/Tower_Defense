using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundsSurvive : MonoBehaviour
{
    //Fonction
    [Header("Text Rounds Survécus")]
    public TMP_Text roundsText;


    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int rounds = 0;

        yield return new WaitForSeconds(0.7f);

        while(rounds < Player_Stat.Rounds)
        {
            rounds++;
            roundsText.text = rounds.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
