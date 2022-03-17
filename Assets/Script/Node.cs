using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    //Fonction
    public Color hoverColor;
    public Color NoEnoughtMoneyColor;
    private Color StartColor;
    public Vector3 PositionsOffset;
    public GameObject Turret;

    private Renderer rend;

    private BuildManager buildManager;

    //Permet de canger de couleur
    private void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    //Savoir ou Construire la toure 
    public Vector3 GetBuildPosition()
    {
        return transform.position + PositionsOffset;
    }

    //Qaund la souris click sur une node
    private void OnMouseDown()
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

        //Permet de ne pas construire sur un nodes deja remplie
        if(Turret != null)
        {
            Debug.Log("Impossible de construire");
            return;
        }

        buildManager.BuildTurretOn(this);
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



        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = NoEnoughtMoneyColor;
        }
    }

    //Permet de decter quand la souris sort de la node
    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
}
