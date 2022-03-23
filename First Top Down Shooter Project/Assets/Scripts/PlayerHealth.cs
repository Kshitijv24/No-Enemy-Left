using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public float maxPlayerHealth;

    [HideInInspector]
    public float currentPlayerHealth;

    public HealthBarScript healthBar;
    public Animator hurtAnimation;

    private Animator cameraAnim;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }

    void Start(){

        currentPlayerHealth = maxPlayerHealth;
        healthBar.SetMaxHealth(maxPlayerHealth);
        cameraAnim = Camera.main.GetComponent<Animator>();
    }

    public void TakeDamage(float damage){

        cameraAnim.SetTrigger("shake");
        hurtAnimation.SetTrigger("hurt");
        currentPlayerHealth -= damage;
        healthBar.SetHealth(currentPlayerHealth);

        if (currentPlayerHealth <= 0)
        {

            Destroy(this.gameObject);
        }
    }

    public void Heal(float healAmount){

        if (currentPlayerHealth + healAmount > maxPlayerHealth){

            currentPlayerHealth = maxPlayerHealth;
            healthBar.SetHealth(currentPlayerHealth);
        }

        else{
            
            currentPlayerHealth += healAmount;
            healthBar.SetHealth(currentPlayerHealth);
        }
    }
}
