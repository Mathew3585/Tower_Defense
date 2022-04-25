using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : MonoBehaviour
{
    //Foncition

    public static int money;
    [Header("Argent du joueur de base"), Tooltip("Cette Variable permet de gére l'argent  du joueur")]
    public int startmoney = 400;
    [Space(10)]
    public static int lives;
    [Header("Vie du joueur de base"), Tooltip("Cette Variable permet de gére la vie du joueur")]
    public int startLife = 100;

    public static int Rounds;

    public void Start()
    {
        Rounds = 0; 
        money = startmoney;
        lives = startLife;
    }

}
