﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay;
    public List<Transform> enemySpawnPointList;

    Coroutine SpawnRoutine;

    void OnEnable()
    {
        if (SpawnRoutine != null)
            StopCoroutine(SpawnRoutine);
        SpawnRoutine = StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            var trial = 10;
            RESPAWN:
            var spawnTransform = enemySpawnPointList[Random.Range(0, enemySpawnPointList.Count)];
            var hits = Physics.OverlapSphere(spawnTransform.position, 0.1f, LayerMask.GetMask("Enemy"));
            if (trial-- > 0 && hits.Count() > 0)
                goto RESPAWN;

            var newEnemy = Instantiate(enemyPrefab, transform);
            newEnemy.transform.position = spawnTransform.position;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
