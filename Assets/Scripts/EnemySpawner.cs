using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<WaveConfig> waveConfigs = null;

    private int startingWaveIndex = 0;

    private void Start()
    {
        WaveConfig currentWave = waveConfigs[0];

        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        int enemiesToSpawn = waveConfig.GetNumberOfEnemies();
        

        for (int enemiesSpawned = 0; enemiesSpawned < enemiesToSpawn; enemiesSpawned ++)
        {
            SpawnEnemy(waveConfig);
            
            float maxSpawnTime = 10f;
            float timeBetweenSpawns = waveConfig.GetTimeBetweenSpawns();
            float randomVariationValue = waveConfig.GetRandomSpawnTimeOffset();
            float randomVariation = Random.Range(-randomVariationValue, randomVariationValue);
            timeBetweenSpawns = Mathf.Clamp(timeBetweenSpawns + randomVariation, 0f, maxSpawnTime);

            yield return new WaitForSeconds(timeBetweenSpawns);
        }

    }

    private void SpawnEnemy(WaveConfig waveConfig)
    {
        GameObject enemyPrefab = waveConfig.GetEnemyPrefab();
        Vector2 startingSpawnLocation = waveConfig.GetWaypoints()[0].transform.position;
        Quaternion startingRotation = Quaternion.identity;


        var newEnemy = Instantiate(enemyPrefab, startingSpawnLocation, startingRotation);
        newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
    }
}
