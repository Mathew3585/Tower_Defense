using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUi : MonoBehaviour
{
    //Fonction
    public GameObject Ui;
    public Node target;

    public TMP_Text upgradeCost;
    public Button upgradeButton;

    public void SetTarget (Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "-" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Max Level";
            upgradeButton.interactable = false;
        }

        Ui.SetActive(true);
    }

    public void Hide()
    {
        Ui.SetActive(false);
    }


    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselecetNode();
    }
}
