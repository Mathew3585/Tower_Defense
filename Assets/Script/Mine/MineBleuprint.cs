using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

[System.Serializable]
public class MineBleuprint
{
    //Fonctions
    public GameObject prefab;
    public int cost;

    //permet de gere l'argent qui et redonner de l'argent au joueur

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
