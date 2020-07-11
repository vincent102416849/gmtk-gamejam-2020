using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodManager : MonoBehaviour
{
    IEnumerator Start()
    {
        while (!FMODUnity.RuntimeManager.HasBankLoaded("Master"))
        {
            Debug.Log("Trying to load master");
            yield return new WaitForSeconds(0.5f);
        }
        FMODUnity.RuntimeManager.PlayOneShot("event:/Music");
    }
}
