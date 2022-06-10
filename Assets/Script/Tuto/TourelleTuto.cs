using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourelleTuto : MonoBehaviour
{
    //Fonctions
    [Header("Général")]

    private Transform target;
    [Header("Range de la tourrelle"), Tooltip("Cette Variable permet de gère la range de la tourelle")]
    public float range = 15f;
    [Header("Tag Ennemyie"), Tooltip("Cette Variable permet de gère les tag des enemies qui est cherhcer par la tourelle")]
    public string enemyTag = "Enemy";
    private EnnemyTuto targetEnemy;
    [Header("Rotations de la tourellle"), Tooltip("Cette Variable permet de gère la rotation de la tourelle")]
    public Transform partToRotate;
    public float turnSpeed = 10f;

    [Header("Balle + Vitesse de tire")]
    public float FireRate = 1f;
    private float fireCountdown = 0f ;
    public GameObject BulletPrefab;
    public Transform firePoint;

    [Header("Son du tire de la Tourelle")]
    public AudioClip[] sounds;
    private AudioSource source;
    [Range(0.1f, 0.5f)]
    public float volumeChangeMultiplier = 0.2f;
    [Range(0.1f, 0.5f)]
    public float pitchChangeMultiplier = 0.2f;

    [Header("Use Lazer")]
    public bool useLaser;
    [Header("Dommage et Slow"), Tooltip("Cette Variable permet de gère les dommage et le ralentissement des ennemies quand la tourelle lazer est activer")]
    public int damageOverTime = 30;
    public float SlowAmout = 0.5f;
    [Header("Effet et particule"), Tooltip("Cette Variable permet de gère les particule de la tourelle lazer")]
    public LineRenderer linerender;
    public ParticleSystem impactEffect;
    public ParticleSystem ImpactParticule;
    [Header("Son du tire de la Tourelle Lazer")]
    public AudioClip[] soundsLazer;
    private AudioSource sourceLazer;
    [Range(0.1f, 0.5f)]
    public float volumeChangeMultiplierLazer = 0.2f;
    [Range(0.1f, 0.5f)]
    public float pitchChangeMultiplierLazer = 0.2f;

    //Lancer en boucle la fonctions Updatetarget
    void Start()
    {
        //ModuleTuto.instance.AddTurret(this);
        source = GetComponent<AudioSource>();
        sourceLazer = GetComponent<AudioSource>();
        InvokeRepeating("Updatetarget", 0f, 0.5f);
    }

    /*private void OnDestroy()
    {
        ModuleTuto.instance.RemoveTurret(this);
    }
    */
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
            targetEnemy = target.GetComponent<EnnemyTuto>();
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


            if (useLaser)
            {
                if (linerender.enabled)
                {
                    linerender.enabled = false;
                    impactEffect.Stop();
                    ImpactParticule.Stop();

                }
            }

            return;
        }

        LockOntarget();

        if(useLaser)
        {
            Laser();
        }
        else
        {
            //Permet de tier
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1 / FireRate;
            }
            //Permet de mettre du delay entre chaque tire
            fireCountdown -= Time.deltaTime;

        }


        void LockOntarget()
        {
            //Calucule la position de l'ennemis moin notre positions
            Vector3 dir = target.position - transform.position;

            //Faire la rotation
            Quaternion LookRotation = Quaternion.LookRotation(dir);
            //Appliquer la rotation
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, LookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        }

        //Uitliser la tourelle lazer pour afficher le les particule et le lazer
        void Laser()
        {
            targetEnemy.TakeDommage(damageOverTime * Time.deltaTime);
            targetEnemy.Slow(SlowAmout);

            if(linerender.enabled == false)
            {
                linerender.enabled = true;
                impactEffect.Play();
                ImpactParticule.Play();
                sourceLazer.clip = soundsLazer[Random.Range(0, soundsLazer.Length)];
                sourceLazer.volume = Random.Range(1 - volumeChangeMultiplierLazer, 1);
                sourceLazer.pitch = Random.Range(1 - pitchChangeMultiplierLazer, 1 + pitchChangeMultiplierLazer);
                sourceLazer.PlayOneShot(sourceLazer.clip);

            }

            //Appliquer la positions au line renderer
            linerender.SetPosition(0, firePoint.position);
            linerender.SetPosition(1, target.position);

            Vector3 dir = firePoint.position - target.position;

            //Donner la bonne rotation
            impactEffect.transform.rotation = Quaternion.LookRotation(dir);

            //Apparaitre les particule sur l'ennemies
            impactEffect.transform.position = target.position + dir.normalized * 1.5f;

        }


        //Faire apparaitre la balle sur le cannon et la lancer sur l'énemi
        void Shoot()
        {
            GameObject bulletGo = (GameObject)Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
            BulletTuto bullet = bulletGo.GetComponent<BulletTuto>();
            Debug.Log("tire");

            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.volume = Random.Range(1 - volumeChangeMultiplier, 1);
            source.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
            source.PlayOneShot(source.clip);

            if(bullet != null)
            {
                bullet.Seek(target);
            }
        }
    }


    //Voire la range des tourelle
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void FireRatetimeUpgarde()
    {
        FireRate = FireRate * 2;
    }
}
