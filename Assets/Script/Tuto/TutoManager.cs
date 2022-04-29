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
    

    public void Start()
    {
        _timer += Time.deltaTime;
        gameManager.SetActive(false);
        ClickMouseBlocker.SetActive(true);
        SpectrumScript.instance.StartAudio(ListAudio [0]);
    }


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

        if (_timer >= Visualizer.GetComponent<SpectrumScript>().GetAudioLenght())
        {
            Visualizer.SetActive(false);
        }
        else
        {
            Visualizer.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            popUpIndex = 1;
            Debug.Log(popUpIndex);
            _timer = 0;
            SpectrumScript.instance.StartAudio(ListAudio[1]);

        }
        else if (popUpIndex == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
                SpectrumScript.instance.StartAudio(ListAudio[2]);
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
                SpectrumScript.instance.StartAudio(ListAudio[3]);
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
                SpectrumScript.instance.StartAudio(ListAudio[4]);
            }
        }
        else if (popUpIndex == 4)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
                SpectrumScript.instance.StartAudio(ListAudio[5]);
            }
        }
        else if (popUpIndex == 5)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
                SpectrumScript.instance.StartAudio(ListAudio[6]);
            }
        }
        else if (popUpIndex == 6)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                Debug.Log(popUpIndex);
                SpectrumScript.instance.StartAudio(ListAudio[7]);
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
                SpectrumScript.instance.StartAudio(ListAudio[8]);
            }
        }
    }

}
