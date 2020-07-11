using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrenghBarDisplay : MonoBehaviour
{
    public Player player;
    public Image strengthImage;
    public List<Sprite> speedAmountSpriteList;

    void Update()
    {
        var value = Mathf.CeilToInt(player.attackPower * 2f);
        strengthImage.sprite = speedAmountSpriteList[value];
    }
}
