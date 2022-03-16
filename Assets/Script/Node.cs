using UnityEngine;

public class Node : MonoBehaviour
{
    //Fonction
    public Color hoverColor;
    private Color StartColor;
    public Vector3 PositionsOffset;
    private GameObject Turret;

    private Renderer rend;

    //Permet de canger de couleur
    private void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
    }

    //Qaund la souris click sur une node
    private void OnMouseDown()
    {
        if(Turret != null)
        {
            Debug.Log("Impossible de construire");
            return;
        }

        //Construire des Tourrelle
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        Turret = (GameObject)Instantiate(turretToBuild, transform.position + PositionsOffset, transform.rotation);
    }



    //Permet de decter quand la souris passe dessus
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    //Permet de decter quand la souris sort de la node
    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
}
