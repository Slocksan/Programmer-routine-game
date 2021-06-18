using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public HealthBar healthBar;

    void Start()
    {
        var health = GetComponent<Health>();
        health.currentHealth = health.maxHealth;
        healthBar.SetMaxHealth(health.maxHealth);
    }
}
