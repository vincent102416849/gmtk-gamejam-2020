using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    IEnumerator Start()
    {
        while (true)
        {
            if (FMODUnity.RuntimeManager.HasBankLoaded("Master"))
            {
                Debug.Log("Master Bank Loaded");
                SceneManager.LoadScene("Room_1", LoadSceneMode.Single);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
