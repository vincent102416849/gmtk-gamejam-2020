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
    public PlayerAnimationController playerAnimationController;

    [Header("Event")]
    public GameEvent OnAttack;

    void Update()
    {
        currentCoolDown = Mathf.MoveTowards(currentCoolDown, 0f, Time.deltaTime);
        if (currentCoolDown > 0f)
            return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerAttack", GetComponent<Transform>().position);
            foreach (var enemyGO in playerSwordDetector.targetGOList)
            {
                var attackData = new AttackData() { fallBack = 5f, fromPosition = transform.position, magic = 1f, strength = player.attackPower };
                if (enemyGO != null)
                    enemyGO.GetComponent<Enemy>().ReceiveAttack(attackData);
            }
            currentCoolDown = player.attackCooldown;
            playerAnimationController.Attack();
            OnAttack.Invoke(this);

            
        }
    }
}
