using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField]
    private GameObject enemyPrefab = null;
    [SerializeField]
    private GameObject pathPrefab = null;
    [SerializeField]
    private float timeBetweenSpawns = 0.5f;
    [SerializeField]
    private float randomSpawnTimeOffset = 0.3f;
    [SerializeField]
    private int numberOfEnemies = 7;
    [SerializeField]
    private float enemyMoveSpeedMultiplier = 1f;

    public GameObject GetEnemyPrefab() {return enemyPrefab;}
    public GameObject GetPathPrefab() {return pathPrefab;}
    public float GetTimeBetweenSpawns() {return timeBetweenSpawns;}
    
    public float GetRandomSpawnTimeOffset() {return randomSpawnTimeOffset;}
    
    public int GetNumberOfEnemies() {return numberOfEnemies;}
    
    public float GetEnemyMoveSpeedMultiplier() {return enemyMoveSpeedMultiplier;}
    
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform waypoint in pathPrefab.transform)
        {
            waveWaypoints.Add(waypoint);
        }

        return waveWaypoints;
    }
    
    
    


}
