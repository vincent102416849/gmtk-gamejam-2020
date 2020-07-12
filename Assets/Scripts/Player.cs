﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Display")]
    public bool isDead;

    [Header("Param")]
    public float attackPower;
    public float health;
    public float moveSpeed;
    public float attackRange;
    public float attackCooldown;

    [Header("Event")]
    public GameEvent OnHpZero;
    public GameEvent OnReceiveAttact;

    public void ReceiveAttack(AttackData attackData)
    {
        if (isDead)
            return;
        UpdateHealth(-attackData.strength);
        OnReceiveAttact.Invoke(attackData);
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerDamage");
    }

    public void UpdateHealth(float healthDelta)
    {
        print($"Player UpdateHealth {healthDelta}");
        health += healthDelta;
        health = Mathf.Clamp(health, 0f, 10f);
        if (Mathf.Approximately(health, 0f))
        {
            OnHpZero.Invoke(this);
            FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerDeath");
        }
        
    }

    public void Die()
    {
        isDead = true;
        gameObject.SetActive(false);
    }
}
