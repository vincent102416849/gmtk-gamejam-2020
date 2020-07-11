using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensorDetector : MonoBehaviour
{
    [Header("Display")]
    public List<GameObject> targetGOList;

    [Header("Param")]
    public TagEnum targetTag;

    [Header("Config")]
    public Enemy enemy;
    public SphereCollider sphereCollider;

    [Header("Event")]
    public GameEvent OnDetectPlayer;

    void Start()
    {
        UpdateValues();
    }

    public void UpdateValues()
    {
        sphereCollider.radius = enemy.detectRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag.ToString()))
        {
            targetGOList.Add(other.gameObject);
            OnDetectPlayer.Invoke(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag.ToString()))
        {
            targetGOList.Add(other.gameObject);
        }
    }
}
