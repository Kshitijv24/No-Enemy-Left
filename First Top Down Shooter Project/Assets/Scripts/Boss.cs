using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float spawnOffset;
    public int damage;
    public GameObject bossDeathEffect;

    private int halfHealth;
    private Animator anim;
    private Transform player;
    private Rigidbody2D rb;
    private Slider healthBarSlider;

    private void Start(){

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        halfHealth = health / 2;
        anim = GetComponent<Animator>();

        healthBarSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        healthBarSlider.maxValue = health;
        healthBarSlider.value = health;
    }

    public void TakeDamage(int damage){

        health -= damage;
        healthBarSlider.value = health;

        if (health <= 0) {

            Instantiate(bossDeathEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            healthBarSlider.gameObject.SetActive(false);
        }

        if(health <= halfHealth){

            anim.SetTrigger("Stage2");
        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.tag == "Player"){

            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private void Update(){

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
