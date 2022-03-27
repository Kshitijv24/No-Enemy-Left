using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseShoot : Enemy
{
    private Rigidbody2D rb;
    private Vector2 movement;

    // shooting variables

    private float timeBtwShots;

    public GameObject bulletPrefab;
    public Transform firePointRight;
    public Transform firePointLeft;

    private void Awake(){

        rb = GetComponent<Rigidbody2D>();
    }

    public override void Start(){

        base.Start();
        timeBtwShots = timeBetweenAttacks;
    }

    void Update(){

        if (timeBtwShots <= 0){

            ShootingFromRight();
            ShootingFromLeft();
        }
        
        else{

            timeBtwShots -= Time.deltaTime;
        }

        if (player != null){

            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate(){

        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction){

        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    // Shooting Functions

    void ShootingFromRight(){

        Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
        timeBtwShots = timeBetweenAttacks;
    }

    void ShootingFromLeft(){

        Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
        timeBtwShots = timeBetweenAttacks;
    }
}