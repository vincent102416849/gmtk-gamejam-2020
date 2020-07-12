﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [Header("Header")]
    public bool isWalking;

    [Header("Config")]
    public Player player;
    public new Rigidbody rigidbody;
    public Transform facingAnchor;
    public Animator animator;

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var velocity = new Vector3(horizontal, vertical, 0f) * player.moveSpeed;
        rigidbody.velocity = velocity;
        isWalking = velocity.magnitude > 0.01f;
        if (Mathf.Abs(vertical) > 0.01f)
        {
            facingAnchor.rotation = Quaternion.Euler(0f, 0f, vertical > 0f ? 90f : 270f);
            player.orientation = vertical > 0f ? Orientation.Back : Orientation.Front;
        }
        if (Mathf.Abs(horizontal) > 0.01f)
        {
            facingAnchor.rotation = Quaternion.Euler(0f, 0f, horizontal > 0f ? 0f : 180f);
            player.orientation = horizontal > 0f ? Orientation.Right : Orientation.Left;
        }
    }
}
