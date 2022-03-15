using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourelle : MonoBehaviour
{
    //Fonctions
    private Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";

    public Transform partToRotate;

    public float turnSpeed = 10f;
    //Lancer en boucle la fonctions Updatetarget
    void Start()
    {
        InvokeRepeating("Updatetarget", 0f, 0.5f);
    }

    //Chercher les ennemis sur la map et les mettre dans une liste 
    void Updatetarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);//chercher par le tag

        //chercher l'�nemie le plus proche
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


    // Faire La rotaion de La tourelle
    void Update()
    {
        if(target == null)
        {
            return;
        }

        //Calucule la position de l'ennemis moin notre positions
        Vector3 dir = target.position - transform.position;

        //Faire la rotation
        Quaternion LookRotation = Quaternion.LookRotation(dir);
        //Appliquer la rotation
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, LookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }


    //Voire la range des tourelle
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
