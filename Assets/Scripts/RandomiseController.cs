using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseController : MonoBehaviour
{
    public Player player;
    public float randomiseTime;

    IEnumerator Start()
    {
        while (true)
        {
            Randomise();
            yield return new WaitForSeconds(randomiseTime);
        }
    }

    public void Randomise()
    {
        player.health = Random.Range(1f, 10f);
        player.moveSpeed = Random.Range(2f, 8f);
    }
}
