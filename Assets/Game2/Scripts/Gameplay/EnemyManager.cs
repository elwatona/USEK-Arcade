using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] enemySpawnPositions, enemyPatrolPositions;
    public Transform player, parent;

    int maxEnemies = 4;
    List<GameObject> activeEnemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    IEnumerator SpawnEnemiesCoroutine()
    {
        while (true)
        {
            activeEnemies.RemoveAll(enemy => enemy == null);
            if (activeEnemies.Count < maxEnemies)
            {
                SpawnEnemies();
            }
            yield return null;
        }
    }

    void SpawnEnemies()
    {
            int randomPrefabIndex = Random.Range(0, enemyPrefabs.Length);
            int randomSpawnIndex = Random.Range(0, enemySpawnPositions.Length);

            GameObject enemyInstance = Instantiate(enemyPrefabs[randomPrefabIndex], enemySpawnPositions[randomSpawnIndex].position, Quaternion.identity, parent);
            activeEnemies.Add(enemyInstance);
            EnemyBehavior enemyBehavior = enemyInstance.GetComponent<EnemyBehavior>();

            if (enemyBehavior != null)
            {
                enemyBehavior.player = player;
                enemyBehavior.patrolPos = enemyPatrolPositions;
            }
        
    }
}
