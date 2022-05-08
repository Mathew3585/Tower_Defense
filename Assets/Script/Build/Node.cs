 using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    //Fonction
    public Color hoverColor;
    public Color NoEnoughtMoneyColor;
    private Color StartColor;
    public Vector3 PositionsOffset;

    [HideInInspector]
    public GameObject Turret;
    [HideInInspector]
    public TourelleBleuprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;

    private BuildManager buildManager;
    AudioSource audioData;


    //Permet de canger de couleur
    private void Start()
    {
        rend = GetComponent<Renderer>();
        //StartColor = rend.material.color;
        buildManager = BuildManager.instance;

    }

    //Savoir ou Construire la toure 
    public Vector3 GetBuildPosition()
    {
        return transform.position + PositionsOffset;
    }


    private void BuildTurret(TourelleBleuprint blueprint)
    {

        //Calculer l'argent du joueur 
        if (Player_Stat.money < blueprint.cost)
        {
            Debug.Log("Pas assez d'argent !!!");
            return;
        }

        Player_Stat.money -= blueprint.cost;

        turretBlueprint = blueprint;

        GameObject turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        Turret = turret;

        Debug.Log("Objet acheter  il vous reste : " + Player_Stat.money);

        GameObject effect = (GameObject)Instantiate(buildManager.ParticuleBuild, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

    }
    public void UpgradeTurret()
    {

        //Calculer l'argent du joueur 
        if (Player_Stat.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Pas assez d'argent pour améliorer la tourelle!!!");
            return;
        }

        Player_Stat.money -= turretBlueprint.upgradeCost;



        //Suppression del'ancien tourrelle
        Destroy(Turret);
        //Créations de la nouvelle tourelle améliorer
        GameObject turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        Turret = turret;

        Debug.Log("Tourelle améliorer");

        GameObject effect = (GameObject)Instantiate(buildManager.ParticuleBuild, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        isUpgraded = true;

        Debug.Log("Tourelle Construite");
    }

    //permet de vendre les tourelles 
    public void SellTurret()
    {
        Player_Stat.money += turretBlueprint.GetSellAmount();
        GameObject effect = (GameObject)Instantiate(buildManager.ParticuleSell, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(Turret);
        turretBlueprint = null;
        isUpgraded = false;
    }
    //Qaund la souris click sur une node
    private void OnMouseDown()
    {
        //Permet de ne pas construire sans faire exprès un tourelle quand on click sur l'ui
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Permet de ne pas construire sur un nodes deja remplie
        if(Turret != null)
        {
            buildManager.SelectedNode(this); 
            return;
        }

        BuildTurret(buildManager.GetTuretToBuild()); 

        //Verifie si on a bien séléctionner un tourrelle dans le shop 
        if (!buildManager.canBuild)
        {
            return;
        }

    }

    //Permet de decter quand la souris passe dessus
    private void OnMouseEnter()
    {
        //Permet de ne pas construire sans faire exprès un tourelle quand on click sur l'ui
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Verifie si on a bien séléctionner un tourrelle dans le shop
        if (!buildManager.canBuild)
        {
            return;
        }


        //Pemet de changer la couleur des nodes quand le joueur a de le'argent ou non
        //if (buildManager.hasMoney)
        {
            //rend.material.color = hoverColor;
        }
        //else
        {
            //rend.material.color = NoEnoughtMoneyColor;
        }
    }

    //Permet de decter quand la souris sort de la node
    private void OnMouseExit()
    {
        //rend.material.color = StartColor;
    }
}
