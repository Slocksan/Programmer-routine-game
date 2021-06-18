using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public HealthBar healthBar;

    void Start()
    {
        Health.currentHealth = Health.maxHealth;
        healthBar.SetMaxHealth(Health.maxHealth);
    }
}
