using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public float timeBetweenAttacks;
    public int healthPickupChance;
    public GameObject healthPickup;

    [HideInInspector]
    public Transform player;

    public GameObject deathEffectPartical;

    public virtual void Start(){

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(float damageAmount){
        
        health -= damageAmount;

        if(health <= 0){

            int randomHealth = Random.Range(0, 101);
            
            if(randomHealth < healthPickupChance){

                Instantiate(healthPickup, transform.position, Quaternion.identity);
            }

            Instantiate(deathEffectPartical, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
