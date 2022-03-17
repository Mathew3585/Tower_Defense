using UnityEngine;

public class Shop : MonoBehaviour
{
    //Fonction
    private BuildManager buildManager;
    public TourelleBleuprint standarTourelle;
    public TourelleBleuprint MissileLancherTurrette;

    //Chercher le build manager
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    //Acheter la tourelle Standar
    public void SelectStandarTuret()
    {
        Debug.Log("Séléction de la tourelle standar!!");
        buildManager.SelectTurretToBuild(standarTourelle);
    }

    //Acheter une tourelle lance missile 
    public void SelectMissileLancherTuret()
    {
        Debug.Log("Séléction de la tourelle Lace missile!!");
        buildManager.SelectTurretToBuild(MissileLancherTurrette);
    }
}
