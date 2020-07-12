using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorials : MonoBehaviour
{
    public GameObject mainGame;
    public GameObject initialTutorial;
    public GameObject statusTutorial;
    public GameObject deathTutorial;

    public int ignore0;

    void Start()
    {
        var it = PlayerPrefs.GetInt("it");
        PlayerPrefs.SetInt("it", it + 1);
        if (it == 0)
        {
            initialTutorial.SetActive(true);
        }
        else
        {
            mainGame.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void OnInitialTutorialFinished()
    {
        mainGame.SetActive(true);
        initialTutorial.SetActive(false);
    }

    public void OnStatusChanged()
    {
        print($"OnStatusChanged {ignore0}");
        if (ignore0++ != 1)
            return;
        mainGame.SetActive(false);
        statusTutorial.SetActive(true);
    }

    public void OnStatusTutorialFinished()
    {
        print($"OnStatusTutorialFinished");
        mainGame.SetActive(true);
        statusTutorial.SetActive(false);
    }

    public void OnPlayerDead()
    {
        print($"OnPlayerDead");
        mainGame.SetActive(false);
        deathTutorial.SetActive(true);
    }

    public void OnPlayerDeadTutorialFinished()
    {
        SceneManager.LoadScene("LandingScene");
    }
}
