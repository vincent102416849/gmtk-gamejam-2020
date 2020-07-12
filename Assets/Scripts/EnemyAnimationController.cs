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
        var targetAnimation = $"{enemy.orientation}_Hit";
        animator.Play(targetAnimation);
        yield return new WaitForSeconds(1f);
        animationCoroutine = StartCoroutine(NormalLoop());
    }

    public void Attack()
    {
        if (animationCoroutine != null)
            StopCoroutine(animationCoroutine);
        animationCoroutine = StartCoroutine(AttackLoop());
    }

    public IEnumerator AttackLoop()
    {
        var targetAnimation = $"{enemy.orientation}_Attack";
        //print(targetAnimation);
        animator.Play(targetAnimation);
        yield return new WaitForSeconds(0.56f);
        animator.Play(lastAnim);
        animationCoroutine = StartCoroutine(NormalLoop());
    }
}
