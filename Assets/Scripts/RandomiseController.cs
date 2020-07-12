using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomiseController : MonoBehaviour
{
    public TextMeshProUGUI countDownText;
    public TextMeshProUGUI debugText;
    public List<float> preconfiguredPower;

    public Player player;
    public float randomiseTime;
    public float countDown;

    public GameEvent OnRandomise;

    IEnumerator Start()
    {
        while (true)
        {
            Randomise();
            countDown = randomiseTime;
            yield return new WaitForSeconds(randomiseTime);
        }
    }

    private void Update()
    {
        countDown -= Time.deltaTime;
        countDownText.SetText($"{countDown:0}");
    }

    public void Randomise()
    {
        var power = preconfiguredPower[Random.Range(0, preconfiguredPower.Count)];
        player.attackPower = power;
        player.moveSpeed = (int) Random.Range(2f, 8f);
        debugText.SetText($"Randomise\nplayer.attackPower:{player.attackPower:0}\nplayer.moveSpeed:{player.moveSpeed }");
        FMODUnity.RuntimeManager.PlayOneShot("event:/StatsReset");
        OnRandomise.Invoke(this);
    }
}
