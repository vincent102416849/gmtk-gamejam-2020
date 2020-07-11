using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomiseController : MonoBehaviour
{
    public TextMeshProUGUI debugText;
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
        player.moveSpeed = (int) Random.Range(2f, 8f);
        debugText.SetText($"Randomise\nplayer.attackPower:{player.attackPower:0}\nplayer.moveSpeed:{player.moveSpeed }");
    }
}
