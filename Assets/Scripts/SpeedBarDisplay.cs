using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBarDisplay : MonoBehaviour
{
    public Player player;
    public Image speedAmountImage;
    public List<Sprite> speedAmountSpriteList;

    void Update()
    {
        var value = Mathf.CeilToInt(player.moveSpeed);
        print(value);
        speedAmountImage.sprite = speedAmountSpriteList[value];
    }
}
