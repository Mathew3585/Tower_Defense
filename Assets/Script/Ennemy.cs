using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    //Fonction
    [Header("Vitesse"), Tooltip("Cette Variable permet de gère la vitesse de l'ennemies")]
    public float StartSpeed = 10;
    [HideInInspector]
    public float speed;
    [Header("Vie"), Tooltip("Cette Variable permet de gère la vie de l'ennemies")]
    public float Health = 100f;
    [Header("Argent drop"), Tooltip("Cette Variable permet de gère l'argent drop")]
    public int worth = 50;
    [Header("Particule de mort"), Tooltip("Cette Variable permet de créer la particule de mort de l'énnemies")]
    public GameObject deadEffect;
    Player_Stat Player;

    //Permet d'apliquer une vitesse a speed 
    public void Start()
    {
        speed = StartSpeed;
    }


    //Permet de prendre des dégat
    public void TakeDommage(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Die();
        }
    }


    //Permet de mourrir
    private void Die()
    {

        Player_Stat.money += worth;

        GameObject deathParticule = (GameObject)Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(deathParticule, 2f);

        Destroy(gameObject);
    }


    //Permet de ralentir l'ennemy
    public void Slow(float amount)
    {
        speed = StartSpeed * (1 - amount);
    } 
}
