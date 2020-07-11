using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    public float respawnDelay;

    public GameObject player;
    public List<Transform> spawnPointList;

    private void Start()
    {
        var spawnTransform = spawnPointList[Random.Range(0, spawnPointList.Count)];
        player.transform.position = spawnTransform.position;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnLoop());
    }

    IEnumerator RespawnLoop()
    {
        yield return new WaitForSeconds(respawnDelay);
        var spawnTransform = spawnPointList[Random.Range(0, spawnPointList.Count)];
        player.GetComponent<Player>().health = 10f;
        player.transform.position = spawnTransform.position;
        player.gameObject.SetActive(true);
    }
}
