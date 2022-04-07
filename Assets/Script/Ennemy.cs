using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ennemy : MonoBehaviour
{
    //Fonction
    [Header("Vitesse"), Tooltip("Cette Variable permet de gère la vitesse de l'ennemies")]
    public float StartSpeed = 10;
    [HideInInspector]
    public float speed;
    [Header("Vie"), Tooltip("Cette Variable permet de gère la vie de l'ennemies")]
    public float StartHealth = 100f;
    private float Health;
    [Header("Argent drop"), Tooltip("Cette Variable permet de gère l'argent drop")]
    public int worth = 50;
    [SerializeField]
    [Header("Dégat"), Tooltip("Cette Variable permet de gérer les dégat des ennmies")]
    private int dammage;
    [Header("Particule de mort"), Tooltip("Cette Variable permet de créer la particule de mort de l'énnemies")]
    public GameObject deadEffect;
    Player_Stat Player;
    [Header("Image de la vie des énnemies"), Tooltip("Cette Variable permet de créer l'ui qui montre la vie des ennmies")]
    public Image healthbar;
    private bool isDead = false;

    //Permet d'apliquer une vitesse a speed 
    public void Start()
    {
        speed = StartSpeed;
        Health = StartHealth;
    }


    //Permet de prendre des dégat
    public void TakeDommage(float amount)
    {
        Health -= amount;
        healthbar.fillAmount = Health / StartHealth;

        if (Health <= 0 && !isDead)
        {
            Die();
        }
    }

    //Permet de ralentir l'ennemy
    public void Slow(float amount)
    {
        speed = StartSpeed * (1 - amount);
    }


    //Permet de mourrir
    private void Die()
    {
        isDead = true;
        Player_Stat.money += worth;

        GameObject deathParticule = (GameObject)Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(deathParticule, 2f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    public void EndOfPath()
    {
        Player_Stat.lives -= dammage;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
