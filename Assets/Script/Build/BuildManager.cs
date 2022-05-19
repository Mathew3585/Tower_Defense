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

    private TourelleBleuprint turretToBluid;
    private Node selectedNode;
    [Header("Node")]
    public NodeUi nodeUi;
    [Header("Particule de Construction")]
    public GameObject ParticuleBuild;
    [Space(5)]
    public GameObject ParticuleSell;
    [Header("Audio de Construction")]
    [Space(5)]
    public AudioClip AudioBuild;
    [Space(5)]
    public AudioClip AudioSell;
    public bool canBuild { get { return turretToBluid != null; } }
    public bool hasMoney { get { return Player_Stat.money >= turretToBluid.cost; } }

    //Mettre un tourelle 


    public void SelectTurretToBuild(TourelleBleuprint turret) 
    {
        turretToBluid = turret;
        selectedNode = null;

        DeselecetNode();
    }

    //Recuper les valeur de turretToBuild 
    public TourelleBleuprint GetTuretToBuild()
    {
        return turretToBluid;
    }

    //Pemermet de savoir si une tourelle et selectionner et afficher Le nodeUi
    public  void SelectedNode(Node node)
    {

        if(node == selectedNode)
        {
            DeselecetNode();
            return;
        }
        Debug.Log("Ok tourelle séléctioner");
        selectedNode = node;
        turretToBluid = null;
        nodeUi.SetTarget(node);
    }

    //Permet de déselect un node
    public void DeselecetNode()
    {
        selectedNode = null;
        nodeUi.Hide();
    }
} 
