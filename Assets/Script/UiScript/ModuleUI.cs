using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ModuleUI : MonoBehaviour
{
    public Module target;
    Tourelle tourelle;
    public Player_Stat player_;
    public Module module;
    public TMP_Text BuyFirerateTimeUpagrade;
    public TMP_Text BuyShieldTimeUpagrade;
    public Button BuyButton;

    public float minimum = 0;
    public float maximum = 20;

    static float t = 0.0f;

    public void SetTarget(Module _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
    }

    public void FirerateTimeUpagrade()
    {
        tourelle.FireRatetimeUpgarde();

        BuildManager.instance.DeselecetNode();
    }
    public void ShieldTimeUpagrade()
    {
        if (Player_Stat.money >= 200 && Player_Stat.lives <= 100 && Player_Stat.lives != 100)
        {
            StartCoroutine("ShieldLife");
            Player_Stat.money -= module.cost;
        }
        else
        {
            Debug.Log("Vie trop haut ou pas assez d'argent");
            return;
        }

    }


    public void Text()
    {
        BuyShieldTimeUpagrade.text = "-" + target.cost;
        BuyButton.interactable = true;
    }


    IEnumerator ShieldLife()
    {


        while (t <= 0.050f)
        {
            t += 0.5f * Time.deltaTime;
            Player_Stat.lives ++;
            Debug.Log(Player_Stat.lives);
            Debug.Log(t);
            yield return new WaitForSeconds(0.01f);
        }

        if (t > 0.050f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
