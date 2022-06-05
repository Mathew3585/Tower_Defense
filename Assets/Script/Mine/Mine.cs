using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float explosionRadius = 10f;

    public GameObject impacteffect;
    public int damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Toucher");
            HitTarget();
        }
    }

    void HitTarget()
    {
        if(explosionRadius > 0)
        {
            GameObject effectIns = (GameObject)Instantiate(impacteffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Expode();
        }
        else
        {
            Debug.Log("Radiuse = null");
            return;
        }
    }


    void Expode()
    {
       Collider[] colliders =  Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
                Destroy(gameObject);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Ennemy e = enemy.GetComponent<Ennemy>();
        if (e != null)
        {
            e.TakeDommage(damage);
        }
        else
        {
            Debug.LogError("Pas de script Enemy sur l'énemi.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
