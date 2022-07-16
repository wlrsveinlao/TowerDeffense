using System.Collections;
using UnityEngine;

public class WaveSpowner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform SpownPoint;
    public float TimeBetWaves = 5f;

    private float countdown = 2f;
    private int waveIndex = 0;


    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetWaves;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpownPoint.position, SpownPoint.rotation);

    }


}
