using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    //Fonction
    public float speed = 10f;
    private Transform target;
    private int waypoinIndex = 0;
    public int Health = 100;
    public int value = 50;
    public GameObject deadEffect;
    Player_Stat Player;

    //trouver les target 
    void Start()
    {
        target = Waypoint_Script.point[0];
    }
    //Déplacer les personnages énnemies au niveaux des waypoints
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Si l'ennemie et a 0.3 du waypoint il passe au prochain 
        if(Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
    }
    //Permet de prendre des dégat
    public void TakeDommage(int amount)
    {
        Health -= amount;

        if(Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        Player_Stat.money += value;

        GameObject deathParticule = (GameObject)Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(deathParticule, 2f);

        Destroy(gameObject);
    }

    //Aller au prochain Waypoint
    private void GetNextWaypoint()
    {

        //SI il n'y a plus de waypoint il détruit l'énémie
        if(waypoinIndex >= Waypoint_Script.point.Length - 1)
        {
            EndPath();
            return;
        }

        //Cherhcer le prochain waypoint
        waypoinIndex++;
        target = Waypoint_Script.point[waypoinIndex];

    }


    private void EndPath()
    {
        Player_Stat.lives--; 
        Destroy(gameObject);
    }
}
