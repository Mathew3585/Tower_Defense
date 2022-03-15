using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Menu_Parameter : MonoBehaviour
{

    public AudioMixer audioMixer;
    public void SetVolume (float volume)
    {

        audioMixer.SetFloat("Volume", volume);
        Debug.Log(volume);
    }
}
