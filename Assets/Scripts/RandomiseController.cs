using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseController : MonoBehaviour
{
    public List<float> preconfiguredPower;

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
        var power = preconfiguredPower[Random.Range(0, preconfiguredPower.Count)];
        player.attackPower = power;
        player.moveSpeed = Random.Range(2f, 8f);
        print($"Randomise\nplayer.attackPower:{player.attackPower}\nplayer.moveSpeed:{player.moveSpeed }");
    }
}
