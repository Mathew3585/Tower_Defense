using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceenFader : MonoBehaviour
{
    //Fonction
    public Image ImgFade;
    public AnimationCurve curve;

    private void Start()
    {
       StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    //Fade in 
    IEnumerator FadeIn()
    {
        float t = 1f;
        while(t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            ImgFade.color = new Color(0f ,0f, 0f, a);
            yield return 0;
        }
    }

    //Fade out 
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            ImgFade.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        //le dode ci-dessus ne se lit que apres ce lui dans haut
        SceneManager.LoadScene(scene);
    }
 
}
