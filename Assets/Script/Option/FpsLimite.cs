using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsLimite : MonoBehaviour
{


    [SerializeField] Text fpsText;
    [SerializeField] int fpsLimit;
    private Slider FpsSlier;
    // Start is called before the first frame update
    void Awake()
    {
        FpsSlier = GameObject.Find("SliderFps").GetComponent<Slider>();
    }

    private void Update()
    {

        fpsLimit = (int)FpsSlier.value;
        Application.targetFrameRate = fpsLimit;
    }


}
