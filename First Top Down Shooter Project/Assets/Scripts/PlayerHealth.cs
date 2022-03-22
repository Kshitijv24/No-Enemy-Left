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

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

        currentPlayerHealth = maxPlayerHealth;
        healthBar.SetMaxHealth(maxPlayerHealth);
    }

    public void TakeDamage(float damage)
    {

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
