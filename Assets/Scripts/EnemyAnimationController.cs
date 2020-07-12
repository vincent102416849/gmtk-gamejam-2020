using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public Coroutine animationCoroutine;

    public Animator animator;
    public Enemy enemy;
    public EnemyMovementController enemyMovementController;
    private string lastAnim;
    public SpriteRenderer spriteRenderer;

    void OnEnable()
    {
        if (animationCoroutine != null)
            StopCoroutine(animationCoroutine);
        animationCoroutine = StartCoroutine(NormalLoop());
    }

    private void OnDisable()
    {
        if (animationCoroutine != null)
            StopCoroutine(animationCoroutine);
    }

    public IEnumerator NormalLoop()
    {
        while (true)
        {
            var targetAnimation = $"{enemy.orientation}";
            lastAnim = targetAnimation;
            animator.Play(targetAnimation);
            yield return null;
        }
    }

    public void BeginAttacked()
    {
        if (animationCoroutine != null)
            StopCoroutine(animationCoroutine);
        animationCoroutine = StartCoroutine(BeingAttackLoop());
    }

    public IEnumerator BeingAttackLoop()
    {
        if (enemy.isDead)
            yield break;
        var targetAnimation = $"{enemy.orientation}_Hit";
        animator.Play(targetAnimation);
        StartCoroutine(BeginAttackLoop());
        yield return new WaitForSeconds(1f);
        animationCoroutine = StartCoroutine(NormalLoop());
    }

    IEnumerator BeginAttackLoop()
    {
        var startTime = Time.time;
        var lerpValue = 1f;
        while (Time.time - startTime < 1f)
        {
            if (lerpValue == 0f)
                lerpValue = 1f - (Time.time - startTime);
            else
                lerpValue = 0f;
            var targetColor = Color.Lerp(Color.white, new Color(1f, 0.4f, 0.4f), lerpValue);
            spriteRenderer.color = targetColor;
            yield return new WaitForSeconds(0.06f);
        }
    }

    public void Attack()
    {
        if (!gameObject.activeInHierarchy)
            return;
        if (animationCoroutine != null)
            StopCoroutine(animationCoroutine);
        animationCoroutine = StartCoroutine(AttackLoop());
    }

    public IEnumerator AttackLoop()
    {
        var targetAnimation = $"{enemy.orientation}_Attack";
        animator.Play(targetAnimation);
        yield return new WaitForSeconds(0.56f);
        animator.Play(lastAnim);
        animationCoroutine = StartCoroutine(NormalLoop());
    }
}
