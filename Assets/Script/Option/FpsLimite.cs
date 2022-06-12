using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FpsLimite : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI fpsText;
    [SerializeField] int fpsLimit;
    private Slider FpsSlier;
    // Start is called before the first frame update
    void Awake()
    {
        FpsSlier = GameObject.Find("SliderFps").GetComponent<Slider>();
        FpsSlier.onValueChanged.AddListener((v) => {
            fpsText.text = v.ToString("0");
        });
    }

    private void Update()
    {

        fpsLimit = (int)FpsSlier.value;
        Application.targetFrameRate = fpsLimit;
    }


}
