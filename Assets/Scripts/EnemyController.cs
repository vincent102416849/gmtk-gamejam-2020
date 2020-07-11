using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

   public float speed;
   public float attack;
   public float reach;
   public float health;

   private Transform target;
    // Start is called before the first frame update
    void Start()
    {
      target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
