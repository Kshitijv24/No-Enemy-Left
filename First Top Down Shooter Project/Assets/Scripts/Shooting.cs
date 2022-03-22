using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePointRight;
    public Transform firePointLeft;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float timeBetweenShots;

    private float shotTime;

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            
            if(Time.time >= shotTime){

                ShootRight();
                ShootLeft();
            }
        }
    }

    void ShootRight(){

        GameObject bullet = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
        shotTime = Time.time + timeBetweenShots;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointRight.up * bulletForce, ForceMode2D.Impulse);
    }

    void ShootLeft(){
        GameObject bullet = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
        shotTime = Time.time + timeBetweenShots;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);
    }
}
