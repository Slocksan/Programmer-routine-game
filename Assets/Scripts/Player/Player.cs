using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public HealthBar healthBar;
    public Health health;

    void Start()
    {
        health.currentHealth = health.maxHealth;
        healthBar.SetMaxHealth(health.maxHealth);
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }
}
