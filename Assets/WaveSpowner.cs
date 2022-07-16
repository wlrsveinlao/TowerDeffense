using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpowner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform SpownPoint;

    public float TimeBetWaves = 5f;

    public Text countDownText;

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

        countDownText.text = Mathf.Round(countdown).ToString();
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpownPoint.position, SpownPoint.rotation);

    }


}
