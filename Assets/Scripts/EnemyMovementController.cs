using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [Header("Display")]
    public bool isWalking;
    public Coroutine enemyRoutine;

    [Header("Param")]
    public float attackRangeThreshold;

    [Header("Config")]
    public Enemy enemy;
    public new Rigidbody rigidbody;
    public EnemySensorDetector enemySensorDetector;
    public EnemyAnimationController enemyAnimationController;

    [Header("Event")]
    public GameEvent OnSuprise;

    void OnEnable()
    {
        if (enemyRoutine != null)
            StopCoroutine(enemyRoutine);
        enemyRoutine = StartCoroutine(HuntingPlayerLoop());
    }

    //public void DetectedPlayer()
    //{
    //    OnSuprise.Invoke(this);
    //    if (enemyRoutine != null)
    //        StopCoroutine(enemyRoutine);
    //    enemyRoutine = StartCoroutine(HuntingPlayerLoop());
    //}

    IEnumerator IdlingLoop()
    {
        while (true)
        {
            isWalking = false;
            yield return null;
        }
    }

    IEnumerator HuntingPlayerLoop()
    {
        GameObject target = null;
        while (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            yield return null;
        }
        
        while (true)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > attackRangeThreshold)
            {
                var direction = (target.transform.position - transform.position).normalized;

                if (Mathf.Abs(direction.x) > 0.01f)
                    enemy.orientation = direction.x > 0f ? Orientation.Right : Orientation.Left;
                if (Mathf.Abs(direction.y) > 0.01f)
                    enemy.orientation = direction.y > 0f ? Orientation.Back : Orientation.Front;

                rigidbody.velocity = direction * enemy.moveSpeed;
                isWalking = true;
            }
            else
            {
                if (!enemy.isDead)
                {
                    isWalking = false;
                    rigidbody.velocity = Vector2.zero;
                    var attackData = new AttackData() { fallBack = 1f, fromPosition = transform.position, magic = 1f, strength = 1f };
                    target.GetComponent<Player>().ReceiveAttack(attackData);
                    enemyAnimationController.Attack();
                }
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    public void Knockback(object attackDataObj)
    {
        Knockback(attackDataObj as AttackData);
        enemyAnimationController.BeginAttacked();
    }

    public void Knockback(AttackData attackData)
    {
        if (!gameObject.activeSelf)
            return;
        if (enemyRoutine != null)
            StopCoroutine(enemyRoutine);
        enemyRoutine = StartCoroutine(KnockbackLoop(attackData));
    }

    IEnumerator KnockbackLoop(AttackData attackData)
    {
        var fallBack = attackData.fallBack;
        var direction = (transform.position - attackData.fromPosition).normalized;
        rigidbody.velocity = direction * fallBack;
        while (rigidbody.velocity.magnitude > 0f)
        {
            rigidbody.velocity = Vector3.MoveTowards(rigidbody.velocity, Vector3.zero, Time.deltaTime * 3f);
            yield return null;
        }
        enemyRoutine = StartCoroutine(HuntingPlayerLoop());
    }
}
