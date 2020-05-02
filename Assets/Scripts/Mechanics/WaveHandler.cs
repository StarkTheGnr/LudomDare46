using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField]
    float firstWaveAfter = 30f, timeBetweenWaves = 15f;

    [SerializeField]
    GameObject[] Waves;

    float waveTimer = 0;
    bool waveEnded = false;
    float firstWaveTimer = 0;
    bool startedFirstWave = false;


    int currentWave = -1;

    public static int enemyCount = -1;

    bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        firstWaveTimer = Time.time;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnded)
        {
            if (!startedFirstWave && (Time.time - firstWaveTimer) >= firstWaveAfter)
            {
                print("First wave started!");
                currentWave++;

                Waves[currentWave].SetActive(true);

                enemyCount = 0;
                int[] enemyNumbers = Waves[currentWave].GetComponentInChildren<WaveSpawner>().count;
                for (int i = 0; i < enemyNumbers.Length; i++)
                {
                    enemyCount += enemyNumbers[i];
                    print(enemyCount);
                }

                startedFirstWave = true;
            }

            if (!waveEnded && enemyCount == 0)
            {
                print("Wave ended!");

                waveEnded = true;
                waveTimer = Time.time;
            }

            if (waveEnded && (Time.time - waveTimer) >= timeBetweenWaves)
            {
                currentWave++;
                print("Wave " + currentWave + " Begins!");

                Waves[currentWave].SetActive(true);

                enemyCount = 0;
                int[] enemyNumbers = Waves[currentWave].GetComponentInChildren<WaveSpawner>().count;
                for (int i = 0; i < enemyNumbers.Length; i++)
                {
                    enemyCount += enemyNumbers[i];
                }

                waveEnded = false;

                if (currentWave == Waves.Length - 1)
                    gameEnded = true;
            }
        }
    }
}
