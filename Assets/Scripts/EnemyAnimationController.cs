using System.Collections;
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
            print(targetAnimation);
            animator.Play(targetAnimation);
            yield return null;
        }
    }

    public void Attack()
    {

    }

    public void OnAttackFinish()
    {

    }
}
