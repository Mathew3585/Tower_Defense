using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlider : MonoBehaviour
{

    public Slider slider;

    public float slidervalue;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("save", slidervalue);
    }

    // Update is called once per frame
    public void ChangeSlider(float value)
    {
        slidervalue = value;
        PlayerPrefs.SetFloat("save", slidervalue);
    }
}
