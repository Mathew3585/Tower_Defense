using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTuto : MonoBehaviour
{
    //Fonction
    public GameObject impactEffect;
    private Transform target;
    public float Speed = 70f;
    public int damage = 50;

    public float explosionsRadius = 0f;

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
        transform.LookAt(target); 
    }

    //Qaund l'ennemis est toucher alors détroire le projectile et faire spawn les particules
    void HitTarget()
    {
       GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
       Destroy(effectIns, 2f);

        if(explosionsRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    //Gerer les exposions
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionsRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    //Gerer les dommage
    void Damage(Transform enemy)
    {
        EnnemyTuto e = enemy.GetComponent<EnnemyTuto>();
        if(e != null)
        {
            e.TakeDommage(damage);
        }
        else
        {
            Debug.LogError("Pas de script Enemy sur l'énemi.");
        }
    }

    //Dessiner le Radius de l'explosion
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, explosionsRadius);
    }
}
