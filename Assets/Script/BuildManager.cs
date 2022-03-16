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


    private GameObject turretToBluid;

    private void Start()
    {
        turretToBluid = StandarTurretPrefab;
    }

    //Mettre tun tourelle
    public GameObject GetTurretToBuild()
    {
        return turretToBluid;
    }



}
