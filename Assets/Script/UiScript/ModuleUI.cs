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
        if (Player_Stat.money >= 200 && Player_Stat.lives <= 100)
        {
            player_.LifeTimeUpagrade();
            Player_Stat.money -= module.cost;
        }
        else
        {
            return;
        }

    }


    public void Text()
    {
        BuyShieldTimeUpagrade.text = "-" + target.cost;
        BuyButton.interactable = true;
    }
}
