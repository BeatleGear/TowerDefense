using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemyIsAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;    

    private float countDown = 1f;

    public TMP_Text countDownText;

    public GameManager gameManager;

    private int waveIndex = 0;
    int wavesLength = 0;

    private void Start()
    {
        EnemyIsAlive = 0;
        wavesLength = waves.Length;
    }
    private void Update()
    {
        if (EnemyIsAlive > 0 )
            return;

        if (countDown <= 0f)
        {
            StartCoroutine( SpawnWave() );
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        countDownText.text = string.Format("{0:00.00}", countDown);

        if ((waveIndex == waves.Length)&&(EnemyIsAlive <= 0))
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemyIsAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds (1f / wave.rate);
        }

        waveIndex++;

        //if (waveIndex == waves.Length)
        //{
        //    gameManager.WinLevel();
        //    this.enabled = false;
        //}
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
