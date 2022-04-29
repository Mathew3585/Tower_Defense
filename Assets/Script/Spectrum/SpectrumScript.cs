using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrumScript : MonoBehaviour
{
    public static SpectrumScript instance;

    //Fonction
    public float MinHeight = 15f;
    public float MaxHeight = 425f;
    public float upadateSenstivity = 0.5f;
    public Color visualierColor = Color.cyan;
    [Space(15) , Range(64,8192)]
    public int visualzerSimples = 64;

    VisualerObjectScript[] visualizerObject;
    public AudioSource m_audiosource;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        visualizerObject = GetComponentsInChildren<VisualerObjectScript>();
        m_audiosource = new GameObject("AudioSource").AddComponent<AudioSource>();
    }

    public void StartAudio(AudioClip audioClip)
    {
        m_audiosource.clip = audioClip;
        m_audiosource.PlayOneShot(audioClip);
    }

    public void StopAudio()
    {
        m_audiosource.Stop();
    }

    public float GetAudioLenght()
    {
        return m_audiosource.clip?.length ?? 0;
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

        }
    }
}
