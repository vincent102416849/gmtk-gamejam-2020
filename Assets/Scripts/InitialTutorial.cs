using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialTutorial : MonoBehaviour
{
    public GameObject mainGameGO;
    public Image image;
    public List<Sprite> spriteList;

    public GameEvent OnPreEnd;
    public GameEvent OnEnd;

    IEnumerator Start()
    {
        for (var i = 0; i < spriteList.Count - 1; i++)
        {
            image.sprite = spriteList[i];
            yield return new WaitForSeconds(2f);
        }
        OnPreEnd.Invoke(this);
        image.sprite = spriteList[spriteList.Count - 1];
        while (!Input.GetKeyDown(KeyCode.Space))
            yield return null;
        OnEnd.Invoke(this);
    }
}
