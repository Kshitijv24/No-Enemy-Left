using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision){

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);
        Destroy(gameObject);

        if(collision.tag == "Enemy"){
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }

        if(collision.tag == "BlueBoss"){
            collision.GetComponent<Boss>().TakeDamage(damage);
        }
    }
}
