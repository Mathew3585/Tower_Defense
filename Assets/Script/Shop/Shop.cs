using UnityEngine;

public class Shop : MonoBehaviour
{
    //Fonction
    private BuildManager buildManager;
    public TourelleBleuprint standarTourelle;
    public TourelleBleuprint MissileLancherTurrette;
    public TourelleBleuprint LazerBeamerTurrette;
    public TourelleBleuprint ElectriqueBeamerTurrette;
    public MineBleuprint MineExplosive;
    public GameObject GoshtTurretSimple;
    public GameObject GoshtMissileLancherTuret;
    public GameObject GoshtLazerBeamer;
    public GameObject GoshtElectriquebeamer;
    public GameObject GoshtMine;
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
        Instantiate(GoshtTurretSimple);
    }

    //Acheter une tourelle lance missile 
    public void SelectMissileLancherTuret()
    {
        Debug.Log("Séléction de la tourelle Lace missile!!");
        buildManager.SelectTurretToBuild(MissileLancherTurrette);
        Instantiate(GoshtMissileLancherTuret);
    }

    //Acheter une tourelle lance missile 
    public void SelectLazerBeamer()
    {
        Debug.Log("Séléction de la tourelle Lazer !!");
        buildManager.SelectTurretToBuild(LazerBeamerTurrette);
        Instantiate(GoshtLazerBeamer);
    }
    public void SelectEletriqueBeamer()
    {
        Debug.Log("Séléction de la tourelle Electrique !!");
        buildManager.SelectTurretToBuild(ElectriqueBeamerTurrette);
        Instantiate(GoshtElectriquebeamer);

    }
    public void SelectMine()
    {
        Debug.Log("Séléction de la Mine!!");
        buildManager.SelectMineTobuild(MineExplosive);
        Instantiate(GoshtMine);
    }
}
