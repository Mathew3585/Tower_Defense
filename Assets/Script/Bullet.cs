using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Fonction
    private Transform target;
    public float Speed = 70f;

    //Chercher la target
    public void Seek(Transform _target)
    {
        target = _target;
    }
    //Si la ball n'a plus de scible alors on la détruit
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;

        //Calculer la magnitude entre le joueur et l'ennemis pour savoir si on a toucher
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}
