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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Start()
    {
        base.Start();
        timeBtwShots = timeBetweenAttacks;
    }

    void Update()
    {

        // shooting code

        if (timeBtwShots <= 0)
        {

            ShootingFromRight();
            ShootingFromLeft();

        }
        else
        {

            timeBtwShots -= Time.deltaTime;
        }


        // second tutorial

        if (player != null)
        {

            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;

            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {

        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    // Shooting Functions

    void ShootingFromRight()
    {

        Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
        timeBtwShots = timeBetweenAttacks;
    }

    void ShootingFromLeft()
    {

        Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
        timeBtwShots = timeBetweenAttacks;
    }
}













// EnemyChaseShoot Original Code

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyChaseShoot : Enemy
//{
//    public float moveSpeed;

//    private GameObject player;
//    private Transform playerTransform;

//    private Rigidbody2D rb;
//    private Vector2 movement;

//    // shooting variables

//    private float timeBtwShots;
//    public float startTimeBtwShots;

//    public GameObject bulletPrefab;
//    public Transform firePointRight;
//    public Transform firePointLeft;

//    private void Awake()
//    {

//        player = GameObject.FindGameObjectWithTag("Player");
//        playerTransform = player.GetComponent<Transform>();
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Start()
//    {

//        timeBtwShots = startTimeBtwShots;
//    }

//    void Update()
//    {

//        // shooting code

//        if (timeBtwShots <= 0)
//        {

//            ShootingFromRight();
//            ShootingFromLeft();

//        }
//        else
//        {

//            timeBtwShots -= Time.deltaTime;
//        }


//        // second tutorial

//        if (player != null)
//        {

//            Vector3 direction = playerTransform.position - transform.position;
//            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
//            rb.rotation = angle;

//            direction.Normalize();
//            movement = direction;
//        }
//    }

//    private void FixedUpdate()
//    {
//        moveCharacter(movement);
//    }

//    void moveCharacter(Vector2 direction)
//    {

//        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
//    }

//    // Shooting Functions

//    void ShootingFromRight()
//    {

//        Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
//        timeBtwShots = startTimeBtwShots;
//    }

//    void ShootingFromLeft()
//    {

//        Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
//        timeBtwShots = startTimeBtwShots;
//    }
//}
