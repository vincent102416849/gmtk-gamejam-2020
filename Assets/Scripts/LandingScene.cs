using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LandingScene : MonoBehaviour
{
   public GameObject Text1;
   public GameObject Text2;
   public GameObject Text3;
   public GameObject Text4;
   public GameObject TextAndTutorial;

    public void Play()
    {
      Debug.Log("Play button pressed");
      StartCoroutine(FadeOutRoutine(Text1));
    }

    public void Option()
    {

    }

    public void Credit()
    {

    }

    private IEnumerator FadeOutRoutine(GameObject card) {
      card.SetActive(true);
      Image image = card.GetComponent<Image>();
      image.color = new Color(1f,1f,1f,1f);
      yield return null;
   }
}
