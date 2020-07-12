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
        SceneManager.LoadScene($"MainGame");
    }

    public void Option()
    {

    }

    public void Credit()
    {
        SceneManager.LoadScene($"Credits");
    }
}
