using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float moveSpeed;
    public float detectRange;

    [Header("Event")]
    public GameEvent OnHpZero;
    public GameEvent OnFallBack;

    public void ReceiveAttack(AttackData attackData)
    {
        print($"Enemy ReceiveAttack");
        UpdateHealth(-attackData.strength);
    }

    public void UpdateHealth(float healthDelta)
    {
        print($"Enemy UpdateHealth {healthDelta}");
        health += healthDelta;
        health = Mathf.Clamp(health, 0f, 10f);
        if (Mathf.Approximately(health, 0f))
            OnHpZero.Invoke(this);
    }
}
