using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [Header("Display")]
    public float currentCoolDown;

    [Header("Config")]
    public Player player;
    public PlayerSwordDetector playerSwordDetector;
    public Animator animator;

    [Header("Event")]
    public GameEvent OnAttack;

    void Update()
    {
        currentCoolDown = Mathf.MoveTowards(currentCoolDown, 0f, Time.deltaTime);
        if (currentCoolDown > 0f)
            return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var enemyGO in playerSwordDetector.targetGOList)
            {
                var attackData = new AttackData() { fallBack = 5f, fromPosition = transform.position, magic = 1f, strength = player.attackPower };
                if (enemyGO != null)
                    enemyGO.GetComponent<Enemy>().ReceiveAttack(attackData);
            }
            currentCoolDown = player.attackCooldown;
            animator.Play("Hero_FrontAttack");
            OnAttack.Invoke(this);

            FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerAttack");
        }
    }
}
