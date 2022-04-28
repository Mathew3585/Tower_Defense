using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutoManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Fonction
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject Visualizer;
    public GameObject gameManager;
    public GameObject ClickMouseBlocker;
    public List<AudioClip> ListAudio;

    private float _timer = 0;
    

    private void Update()
    {
        //Afficher le popIndex avec +1
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
                
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if(popUpIndex == 0) 
        {
            _timer += Time.deltaTime;
            gameManager.SetActive(false);
            ClickMouseBlocker.SetActive(true);

            if(_timer >= Visualizer.GetComponent<SpectrumScript>().GetAudioLenght())
            {
                Visualizer.SetActive(false);
            }
            else
            {
                Visualizer.SetActive(true);
                Visualizer.GetComponent<SpectrumScript>().StartAudio(ListAudio[0]);
            }

            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex = 1;
                _timer = 0;
                Debug.Log(popUpIndex);
 
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
            }
        }
        else if (popUpIndex == 4)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
            }
        }
        else if (popUpIndex == 5)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
            }
        }
        else if (popUpIndex == 6)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
            }
        }
        else if (popUpIndex == 7)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                gameManager.SetActive(true);
                ClickMouseBlocker.SetActive(false);
                Debug.Log(popUpIndex);
            }
        }
    }

}
