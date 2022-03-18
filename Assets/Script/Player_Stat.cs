using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : MonoBehaviour
{
    //Foncition
    public static int money;
    public int startmoney = 400;
    public static int lives;
    public int startLife = 20;

    public void Start()
    {
        money = startmoney;
        lives = startLife;

    }

}
