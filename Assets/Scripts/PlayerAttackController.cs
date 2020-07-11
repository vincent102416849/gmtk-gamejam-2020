using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [Header("Config")]
    public Player player;
    public PlayerSwordDetector playerSwordDetector;

    [Header("Event")]
    public GameEvent OnAttack;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var enemyGO in playerSwordDetector.targetGOList)
            {
                var attackData = new AttackData() { fallBack = 1f, fromPosition = transform.position, magic = 1f, strength = 1f };
                enemyGO?.GetComponent<Enemy>().ReceiveAttack(attackData);
            }
            OnAttack.Invoke(this);

            FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerAttack");
        }
    }
}
