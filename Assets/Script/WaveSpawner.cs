using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //Fonctions
    [SerializeField]
    private Transform ennemyPrefabs;
    [SerializeField]
    private float TimesBetweenspawn;
    [SerializeField]
    private Transform SpawnPoint;
    [SerializeField]
    private Text waveCountdoawnTimer;
    [SerializeField]
    private float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;

    void Update()
    {
        //Si le compteur de début de partie et = 0 alors on lance la game
        if (countdown <= 0f) 
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        //Chaque seconde qui passe on retire 1 à  countdown
        countdown -= Time.deltaTime;
        // modifer le text Countdown 
        waveCountdoawnTimer.text = Mathf.Round(countdown).ToString();
    }
    
    //Lance la game
    IEnumerator SpawnWave()
    {
        waveIndex++; //Changer de manche
        Debug.Log("Apparitions d'une nouvelle vague");

        //Delay entre chaque spawn
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(TimesBetweenspawn);
        }
    }

    //Faire Spawn les ennemies 
    void SpawnEnemy()
    {
        Instantiate(ennemyPrefabs, SpawnPoint.position, SpawnPoint.rotation);
    }
}
