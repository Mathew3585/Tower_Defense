using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class EnnemyTuto : MonoBehaviour
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
    [Header("Gérer le Camera Shake"), Tooltip("Cette Variable permet de gérer le camera shake")]
    public CameraShaker camerashake;
    public GameObject ImageDegat;
    public GameObject ImageLowLife;
    public GameObject meshRenderer;
    private Collider collider;
    [SerializeField] GameObject Ui;
    public float DurationShake = 0.15f;
    public float MagnitueShake = 0.4f;


    //Permet d'apliquer une vitesse a speed 
    public void Start()
    {

        ImageDegat = GameManagerTuto.instance.ImageDégat;
        ImageLowLife = GameManagerTuto.instance.ImageLowLife;
        collider = GetComponent<Collider>();
        Debug.Log(ImageDegat);
        camerashake = Camera.main.gameObject.GetComponent<CameraShaker>();
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

        WaveSpawnerTuto.EnemiesAlive--;

        Destroy(gameObject);
    }

    //permet de mettre des dégat au joueur quand il arrive a la fin des waypoints
    public void EndOfPath()
    {
        if (isDead)
        {
            return;
        }
        else if (!isDead)
        {
            isDead = true;
            Player_Stat.lives -= dammage;
            Debug.Log("DommageUi");
            WaveSpawnerTuto.EnemiesAlive--;
            StartCoroutine("DommageUi");
            if(Player_Stat.lives <= 40)
            {
                StartCoroutine("Dommage20hp");
            }

        }

    }

    IEnumerator DommageUi()
    {
        ImageDegat.SetActive(true);
        meshRenderer.SetActive(false);
        collider.enabled = false;
        Ui.SetActive(false);
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        yield return new WaitForSeconds(3);
        ImageDegat.SetActive(false);
        Destroy(gameObject);
    }


    IEnumerator Dommage20hp()
    {
        ImageDegat.SetActive(true);
        ImageLowLife.SetActive(true);
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        yield return new WaitForSeconds(3);
        ImageDegat.SetActive(false);
        ImageLowLife.SetActive(false);
    }

}
