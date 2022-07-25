using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpowner : MonoBehaviour
{
    // ref to own prefabs things, like enemys and "start" object
    public Transform enemyPrefab;   
    public Transform SpownPoint;

    // time between waves, defoult 5sec
    public float TimeBetWaves = 5f;

    // ref to Convas Text, for show time between waves
    public Text countDownText;

    // first wave countdown
    private float countdown = 2f;
    
    //count of waves;
    private int waveIndex = 0;


    private void Update()
    {   
        //if countdown will == 0sec, then will spown first wave
        if (countdown <= 0f)
        {
            // after first one, countdown will enter the "timeBetWaves" count
            StartCoroutine(SpawnWave());
            countdown = TimeBetWaves;
        }
        // is this need for fps 
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        // remove float thing of nubers to int, and return sec to main camera
        countDownText.text = string.Format("{0:00.00}", countdown);
    }
    // using Ienumerator to make routine, and fix copy enemyes
    IEnumerator SpawnWave()
    {
        // just count of waves 
        waveIndex++;

        // on every wave, enemy will creates +1 like wavecount
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();

            // is that distance of enemy, but of spawnTime;
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    void SpawnEnemy()
    {
        //Instantiate is metod for Spawn something in game, when we are playing
        Instantiate(enemyPrefab, SpownPoint.position, SpownPoint.rotation);

    }


}
