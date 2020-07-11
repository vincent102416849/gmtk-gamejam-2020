using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarDisplay : MonoBehaviour
{
    public Player player;
    public Image hpAmountImage;
    public List<Sprite> hpAmountSpriteList;

    void Update()
    {
        var value = Mathf.CeilToInt(player.health);
        hpAmountImage.sprite = hpAmountSpriteList[value];
    }
}
