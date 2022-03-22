using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount;
    public GameObject pickUpEffect;
    private PlayerHealth playerHealth;

    private void Awake(){

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.tag == "Player"){

            Instantiate(pickUpEffect, transform.position, Quaternion.identity);

            playerHealth.Heal(healAmount);
            Destroy(gameObject);
        }
        
    }
}
