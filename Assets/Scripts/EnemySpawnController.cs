using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay;
    public List<Transform> enemySpawnPointList;

    IEnumerator Start()
    {
        while (true)
        {
            var spawnTransform = enemySpawnPointList[Random.Range(0, enemySpawnPointList.Count)];
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = spawnTransform.position;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
