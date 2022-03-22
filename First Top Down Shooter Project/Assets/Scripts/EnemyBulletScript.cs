using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed;
    public float damage;

    private PlayerHealth playerScript;
    private Vector2 targetPosition;

    private void Start(){

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        targetPosition = playerScript.transform.position;
    }

    private void Update(){
        
        if(Vector2.Distance(transform.position, targetPosition) > 0.1f){

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        } 
        
        else{

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.tag == "Player"){

            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
