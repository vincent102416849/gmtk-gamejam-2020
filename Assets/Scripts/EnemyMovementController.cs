using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [Header("Display")]
    public Coroutine enemyRoutine;

    [Header("Param")]
    public float attackRangeThreshold;

    [Header("Config")]
    public Enemy enemy;
    public new Rigidbody rigidbody;
    public EnemySensorDetector enemySensorDetector;

    [Header("Event")]
    public GameEvent OnSuprise;

    void Start()
    {
        enemyRoutine = StartCoroutine(IdlingLoop());
    }

    public void DetectedPlayer()
    {
        OnSuprise.Invoke(this);
        if (enemyRoutine != null)
            StopCoroutine(enemyRoutine);
        enemyRoutine = StartCoroutine(HuntingPlayerLoop());
    }

    IEnumerator IdlingLoop()
    {
        while (true)
        {
            yield return null;
        }
    }

    IEnumerator HuntingPlayerLoop()
    {
        var target = enemySensorDetector.targetGOList.First();
        yield return new WaitForSeconds(0f);
        while (true)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > attackRangeThreshold)
            {
                var direction = (target.transform.position - transform.position).normalized;
                rigidbody.velocity = direction * enemy.moveSpeed;
            }
            else
            {
                rigidbody.velocity = Vector2.zero;
                var attackData = new AttackData() { fallBack = 1f, fromPosition = transform.position, magic = 1f, strength = 1f };
                target.GetComponent<Player>().ReceiveAttack(attackData);
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }
}
