using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using TMPro;

public class WaveSpawner: MonoBehaviour
{
    //Fonctions

    [Header("Gestionnaire des Manche"), Tooltip("Cette Variable permet de générer des vagues d'ennemies.")]
    public static int EnemiesAlive = 0;
    [Space(10)]
    [Header("Point de spawn et Waypoint List"), Tooltip("Cette Variable permet de gére les point de spawn")]
    public List<Transform> SpawnPoint;
    [Space(10)]
    public List<Waypoint_Script> WayPointsList;
    [Space(10)]
    [Header("Nombre de Vagues"), Tooltip("Cette Variable permet de gére les vagues")]
    public Wave[] waves;
    [Space(10)]
    [Header("Temp de chaque vagues "), Tooltip("Cette Variable permet de gére le Temp de Chaque vagues")]
    public float countdown = 5f;
    [Space(5)]
    public TMP_Text waveCountdoawnTimer;
    [Space(10)]
    private float timeBetweenWaves = 5f;
    [Space(10)]
    [Header("Audio Clip qui annonce les vagues"), Tooltip("Cette Variable permet de gére l'audio clip d'annonce des vagues")]
    [Space (10)]
    public AudioClip SoundWaveAnonnce;
    AudioSource audioSource;
    [Header("GameManager"), Tooltip("Cette Variable permet de gére le GameManager")]
    public GameManager gameManager;
    [Space(10)]
    private int waveIndex = 0;
 



    private void Start()
    {       
        EnemiesAlive = 0;
        audioSource = new GameObject("AudioSource_WaveSpawner").AddComponent<AudioSource>();
    }
    void Update()
    {

        if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.Winlevel();
            this.enabled = false;
        }

        //Si le compteur de début de partie et <= 0 alors on lance la game
        if (countdown <= 0f) 
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        //Chaque seconde qui passe on retire 1 à  countdown
        countdown -= Time.deltaTime;

        // modifer le text Countdown 
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdoawnTimer.text = string.Format("{0:00.00}", countdown);
    }
    
    //Lance la game
    IEnumerator SpawnWave()
    {

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        Debug.Log("Apparitions d'une nouvelle vague");
        Player_Stat.Rounds++;
        audioSource.PlayOneShot(SoundWaveAnonnce, 0.7F);

        //Delay entre chaque spawn
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;


    }

    //Faire Spawn les ennemies 
    void SpawnEnemy(GameObject enemy)
    {
        int Rand = Random.Range(0, WayPointsList.Count);
        var currentEnemy = Instantiate(enemy, SpawnPoint[Rand].position, SpawnPoint[Rand].rotation);
        currentEnemy.GetComponent<EnemyMouvement>().Waypoint_Script = WayPointsList[Rand];
    }
}
