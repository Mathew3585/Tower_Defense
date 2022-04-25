using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CurvedUIUtility;

public class SpectrumScript : MonoBehaviour
{

    //Fonction
    public float MinHeight = 15f;
    public float MaxHeight = 425f;
    public float upadateSenstivity = 0.5f;
    public Color visualierColor = Color.cyan;
    [Space(15) , Range(64,8192)]
    public int visualzerSimples = 64;

    VisualerObjectScript[] visualizerObject;
    AudioSource m_audiosource;


    // Start is called before the first frame update
    void Start()
    {
        visualizerObject = GetComponentsInChildren<VisualerObjectScript>();
        m_audiosource = new GameObject ("AudioSource").AddComponent<AudioSource>();
        
    }

    public void StartAudio(AudioClip audioClip)
    {
        m_audiosource.clip = audioClip;
        m_audiosource.Play();
    }

    public void StopAudio()
    {
        m_audiosource.Stop();
    }

    public float GetAudioLenght()
    {
        return m_audiosource.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrumData = m_audiosource.GetSpectrumData(visualzerSimples, 0, FFTWindow.Rectangular);

        for (int i = 0; i < visualizerObject.Length; i++)
        {
            Vector2 newSize = visualizerObject[i].GetComponent<RectTransform>().rect.size;
            newSize.y = Mathf.Clamp(Mathf.Lerp(newSize.y, MinHeight + (spectrumData[i] * (MaxHeight - MinHeight) * 5f), upadateSenstivity), MinHeight, MaxHeight);
            visualizerObject[i].GetComponent<RectTransform>().sizeDelta = newSize;

            visualizerObject[i].GetComponent<CurvedImage>().color = visualierColor;
        }
    }
}
