using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public Coroutine animationCoroutine;

    public Animator animator;
    public Player player;
    public PlayerMoveController playerMoveController;

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
            if (playerMoveController.isWalking)
            {
                var targetAnimation = $"Hero_{player.orientation}Walk";
                print(targetAnimation);
                animator.Play(targetAnimation);
            }
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
