using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutoManagerTuto : MonoBehaviour
{
    // Start is called before the first frame update
    //Fonction
    [Header("Popup"), Tooltip("Cette Variable permet de gère le nombre de popup")]
    public GameObject[] popUps;
    [Header("Tuto Manager"), Tooltip("Cette Variable permet de renseigner le tuto Manager")]
    public GameObject tutoManager;
    public int popUpIndex;
    [Header("Visualizer"), Tooltip("Cette Variable permet de renseigner le visualizer")]
    public GameObject Visualizer;
    [Header("Game Manager"), Tooltip("Cette Variable permet de renseigner le Game Manager")]
    public GameObject gameManager;
    [Header("ClickMouseBlocker"), Tooltip("Cette Variable permet de renseigner le ClickMouseBlocker")]
    public GameObject ClickMouseBlocker;
    [Header("List Audio"), Tooltip("Cette Variable permet de renseigner la List Audio")]
    public List<AudioClip> ListAudio;
    private float _timer = 0;
    public Button button;
    public Button Upagradebutton;
    public bool Shopclick;
    public bool UpagradClick;
    public GameObject UiWin;
    public WaveSpawnerTuto waveSpawner;

    //Sart du jeu 
    public void Start()
    {
        button.onClick.AddListener(() => Shopclick = true);
        Upagradebutton.onClick.AddListener(() => UpagradClick = true);
        _timer += Time.deltaTime;
        gameManager.SetActive(false);
        ClickMouseBlocker.SetActive(true);
        SpectrumScript.instance.StartAudio(ListAudio [0]);
    }

    //Update
    private void Update()
    {
        
        PupupIndexParamter();
        GetLenghtaudio();
        PopupParamter();
    }


    //Avoir la Longeur du clip audio
    public void GetLenghtaudio()
    {
        if (_timer >= Visualizer.GetComponent<SpectrumScript>().GetAudioLenght())
        {
            Visualizer.SetActive(false);
        }
        else
        {
            Visualizer.SetActive(true);
        }
    }

    public void PupupIndexParamter()
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

    }

    //Régler les parametre des popups
    public void PopupParamter()
    {
        Debug.Log("I : " + popUpIndex);

        if (popUpIndex == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
                _timer = 0;
                SpectrumScript.instance.StartAudio(ListAudio[1]);

            }
        }

        else if (popUpIndex == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _timer = 0;
                popUpIndex++;
                SpectrumScript.instance.StartAudio(ListAudio[2]);
                ClickMouseBlocker.SetActive(false);
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _timer = 0;
                popUpIndex++;
                gameManager.SetActive(true);
                SpectrumScript.instance.StartAudio(ListAudio[3]);
            }
        }
        else if (popUpIndex == 3 && Shopclick)
        {
            _timer = 0;
            popUpIndex++;
            SpectrumScript.instance.StartAudio(ListAudio[4]);
        }
        else if (popUpIndex == 4 && UpagradClick)
        {
            popUpIndex++;
            _timer = 0;
            gameManager.SetActive(false);
            SpectrumScript.instance.StartAudio(ListAudio[5]);

        }
        else if (popUpIndex == 5 )
        {
            if(Input.GetMouseButtonDown(0))
            {
                _timer = 0;
                popUpIndex++;
                SpectrumScript.instance.StartAudio(ListAudio[6]);
                UiWin.SetActive(true);
            }

        }
    }

}
