using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Param")]
    public float moveSpeed;

    [Header("Config")]
    public new Rigidbody rigidbody;

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var delta = new Vector3(horizontal, vertical, 0f) * moveSpeed;
        rigidbody.velocity = delta;
    }
}
