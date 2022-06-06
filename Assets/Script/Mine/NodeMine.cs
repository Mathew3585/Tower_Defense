 using UnityEngine;
using UnityEngine.EventSystems;

public class NodeMine : MonoBehaviour
{
    //Fonction
    public Color hoverColor;
    public Color NoEnoughtMoneyColor;
    private Color StartColor;
    public Vector3 PositionsOffset;

    [HideInInspector]
    public GameObject Mine;
    [HideInInspector]
    public MineBleuprint mineBleuprint;
    [HideInInspector]
    public bool isUpgraded = false;
    public bool useLaser;

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


    private void BuildTurret(MineBleuprint blueprint)
    {

        //Calculer l'argent du joueur 
        if (Player_Stat.money < blueprint.cost)
        {
            Debug.Log("Pas assez d'argent !!!");
            return;
        }

        Player_Stat.money -= blueprint.cost;

        mineBleuprint = blueprint;

        GameObject turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        Mine = turret;

        Debug.Log("Objet acheter  il vous reste : " + Player_Stat.money);

        GameObject effect = (GameObject)Instantiate(buildManager.ParticuleBuild, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

    }


    //permet de vendre les tourelles 
    public void SellTurret()
    {
        Player_Stat.money += mineBleuprint.GetSellAmount();
        GameObject effect = (GameObject)Instantiate(buildManager.ParticuleSell, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(Mine);
        mineBleuprint = null;
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
        if(Mine != null)
        {
            buildManager.SelectedNodeMine(this); 
            return;
        }

        BuildTurret(buildManager.GetMinetobuild()); 

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
