using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWaves = 5.5f;
    public Transform spawnPoint;

    private float countDown = 2f;

    public TMP_Text countDownText;

    private int waveIndex = 0;

    private void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine( SpawnWave() );
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        countDownText.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming");

        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }
     void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
