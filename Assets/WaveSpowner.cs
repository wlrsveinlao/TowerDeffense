using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpowner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform SpownPoint;
    public float TimeBetWaves = 5f;

    private float countdown = 2f;
    private int waveNumber = 1;


    private void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = TimeBetWaves;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerable SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }

        waveNumber++;
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpownPoint.position, SpownPoint.rotation);

    }


}
