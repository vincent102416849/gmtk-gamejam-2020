using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float moveSpeed;
    public float attackRange;

    [Header("Event")]
    public GameEvent OnHpZero;
    public GameEvent OnReceiveAttact;

    public void ReceiveAttack(AttackData attackData)
    {
        print($"Player ReceiveAttack");
        UpdateHealth(-attackData.strength);
        OnReceiveAttact.Invoke(attackData);
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
