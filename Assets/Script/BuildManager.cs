using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    //Faire une reference à un autre sript
    public static BuildManager instance;

    //Chercher un BuildManager Sur la scène 
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Il y a des déja un Build Manager dans la scène !!!");
        }
        instance = this;
    }
    #endregion

    //Fonctions
    public GameObject StandarTurretPrefab;
    public GameObject MissileLancherTurretPrefab;

    private TourelleBleuprint turretToBluid;

    public GameObject ParticuleBuild;
    public bool canBuild { get { return turretToBluid != null; } }
    public bool hasMoney { get { return Player_Stat.money >= turretToBluid.cost; } }

    //permettre de construire un tourelle
    public void BuildTurretOn(Node node)
    {

        //Calculer l'argent du joueur 
        if (Player_Stat.money < turretToBluid.cost)
        {
            Debug.Log("Pas assez d'argent !!!");
            return;
        }

        Player_Stat.money -= turretToBluid.cost;

       GameObject turret = (GameObject)Instantiate(turretToBluid.prefab, node.GetBuildPosition(), Quaternion.identity);
       node.Turret = turret;

        Debug.Log("Objet acheter  il vous reste : " + Player_Stat.money);

        GameObject effect = (GameObject)Instantiate(ParticuleBuild, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);
    }

    //Mettre un tourelle


    public void SelectTurretToBuild(TourelleBleuprint turret)
    {
        turretToBluid = turret;
    }

}
