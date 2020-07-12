﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public Coroutine animationCoroutine;

    public Animator animator;
    public Enemy enemy;
    public EnemyMovementController enemyMovementController;

    void Start()
    {
        animationCoroutine = StartCoroutine(NormalLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator NormalLoop()
    {
        while (true)
        {
            var targetAnimation = $"{enemy.orientation}";
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

    }

    public void AttackFinish()
    {

    }
}
