using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    

    void Start()
    {
        if (FMODUnity.RuntimeManager.HasBankLoaded("Master Bank"))
        {
            Debug.Log("Master Bank Loaded");
            SceneManager.LoadScene("Room_1", LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
