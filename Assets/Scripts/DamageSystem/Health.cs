using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public HealthBar healthBar;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Destroy(gameObject);
        healthBar.SetHealth(currentHealth);
    }

    public void Healing(int bonusHealth)
    {
        currentHealth += bonusHealth;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

}
