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

    private void OnEnable()
    {
        if (FindObjectOfType<Player>() == null)
        {
            var spawnTransform = spawnPointList[Random.Range(0, spawnPointList.Count)];
            player.GetComponent<Animator>().Play($"Hero_Idle");
            player.GetComponent<Player>().isDead = false;
            player.GetComponent<Player>().health = 10f;
            player.transform.position = spawnTransform.position;
            player.gameObject.SetActive(true);
            FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSpawn");
        }
    }

    public void Respawn()
    {
        StartCoroutine(RespawnLoop());
    }

    IEnumerator RespawnLoop()
    {
        yield return new WaitForSeconds(respawnDelay);
        var spawnTransform = spawnPointList[Random.Range(0, spawnPointList.Count)];
        player.GetComponent<Animator>().Play($"Hero_Idle");
        player.GetComponent<Player>().isDead = false;
        player.GetComponent<Player>().health = 10f;
        player.transform.position = spawnTransform.position;
        player.gameObject.SetActive(true);
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSpawn");
    }
}
