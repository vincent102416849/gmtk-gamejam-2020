using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordDetector : MonoBehaviour
{
    [Header("Display")]
    public List<GameObject> targetGOList;

    [Header("Param")]
    public TagEnum targetTag;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag.ToString()))
        {
            targetGOList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag.ToString()))
        {
            targetGOList.Remove(other.gameObject);
        }
    }
}
