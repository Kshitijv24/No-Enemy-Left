using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : Enemy
{
    public float stopDistance;
    public float attackSpeed;
    public float damage;

    private Rigidbody2D rb;
    private float attackTime;

    private void Awake(){

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){

        if (player != null){

            if(Vector2.Distance(transform.position, player.position) > stopDistance){

                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
            } else{

                if(Time.time >= attackTime){

                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }

    IEnumerator Attack(){

        PlayerHealth.instance.TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 tartgetPosition = player.position;

        float percent = 0;
        
        while(percent <= 1){
            
            percent += Time.deltaTime * attackSpeed;
            float animationFormula = (-Mathf.Pow(percent, 2) + percent) * 4;

            transform.position = Vector2.Lerp(originalPosition, tartgetPosition, animationFormula);
            yield return null;
        }
    }
}