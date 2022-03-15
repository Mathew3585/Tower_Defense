using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourelle : MonoBehaviour
{
    //Fonctions
    public Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";

    //Lancer en boucle la fonctions Updatetarget
    void Start()
    {
        InvokeRepeating("Updatetarget", 0f, 0.5f);
    }

    //Chercher les ennemis sur la map et les mettre dans une liste 
    void Updatetarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);//chercher par le tag

        //chercher l'énemie le plus proche
        float shortDistance = Mathf.Infinity;
        GameObject nearstEnemy = null;

        //Lister l'enemies le plus proche
        foreach (GameObject enemy in ennemies )
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy;
                nearstEnemy = enemy;
            }
        }
        //recuper l'ennemy le plus proche et 
        if(nearstEnemy != null && shortDistance <= range)
        {
            target = nearstEnemy.transform;
        }
        else
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    //Voire la range des tourelle
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
