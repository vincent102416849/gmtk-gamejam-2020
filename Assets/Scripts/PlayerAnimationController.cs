using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Coroutine animationCoroutine;
    public Coroutine flashCoroutine;

    public Animator animator;
    public Player player;
    public PlayerMoveController playerMoveController;
    public SpriteRenderer spriteRenderer;

    void OnEnable()
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
                //print(targetAnimation);
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

    public void GetHit()
    {
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);
        flashCoroutine = StartCoroutine(GetHitLoop());
    }

    IEnumerator GetHitLoop()
    {
        var startTime = Time.time;
        var lerpValue = 1f;
        while (Time.time - startTime < 1f)
        {
            if (lerpValue == 0f)
                lerpValue = 1f - (Time.time - startTime);
            else
                lerpValue = 0f;
            var targetColor = Color.Lerp(Color.white, Color.red, lerpValue);
            spriteRenderer.color = targetColor;
            yield return new WaitForSeconds(0.06f);
        }
    }
}
