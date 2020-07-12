using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Display")]
    public Orientation orientation;
    public bool isDead;

    [Header("Param")]
    public float health;
    public float moveSpeed;
    public float detectRange;

    [Header("Config")]
    public SpriteRenderer spriteRenderer;

    [Header("Event")]
    public GameEvent OnHpZero;
    public GameEvent OnReceiveAttact;

    public void ReceiveAttack(AttackData attackData)
    {
        if (isDead)
            return;
        UpdateHealth(-attackData.strength);
        OnReceiveAttact.Invoke(attackData);
        FMODUnity.RuntimeManager.PlayOneShot("event:/EnemyDamage", GetComponent<Transform>().position);
    }

    public void UpdateHealth(float healthDelta)
    {
        //print($"Enemy UpdateHealth {healthDelta}");
        health += healthDelta;
        health = Mathf.Clamp(health, 0f, 10f);
        if (Mathf.Approximately(health, 0f))
            OnHpZero.Invoke(this);
    }

    public void Die()
    {
        if (isDead)
            return;
        isDead = true;
        StartCoroutine(DeadLoop());
    }

    IEnumerator DeadLoop()
    {
        var startTime = Time.time;
        var alpha1 = 1f;
        var alpha2 = 0.3f;
        while (Time.time - startTime < 1f)
        {
            var targetAlpha = 0f;
            if (spriteRenderer.color.a == alpha1)
            {
                alpha1 -= 0.05f;
                alpha2 -= 0.05f;
                targetAlpha = alpha2;
            }
            else
            {
                alpha1 -= 0.05f;
                alpha2 -= 0.05f;
                targetAlpha = alpha1;
            }
            var targetColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, targetAlpha);
            spriteRenderer.color = targetColor;
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
    }
}
