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
                var attackData = new AttackData() { fallBack = 1f, fromPosition = transform.position, magic = 1f, strength = player.attackPower };
                enemyGO?.GetComponent<Enemy>().ReceiveAttack(attackData);
            }
            currentCoolDown = player.attackCooldown;
            OnAttack.Invoke(this);

            FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerAttack");
        }
    }
}
