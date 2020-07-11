using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformOffsetFollow : MonoBehaviour
{
    [Header("Display")]
    public Vector3 offset;

    [Header("Config")]
    public Transform targetTrans;

    void Start()
    {
        offset = transform.position - targetTrans.position;
    }

    void Update()
    {
        transform.position = targetTrans.position + offset;
    }
}
