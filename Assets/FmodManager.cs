using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (FMODUnity.RuntimeManager.HasBankLoaded("Master"))
        {
            Debug.Log("Master");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Music");
          
        }



    }
}
