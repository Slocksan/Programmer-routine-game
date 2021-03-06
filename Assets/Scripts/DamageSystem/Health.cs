using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public HealthBar healthBar;
    public LoadScene loadScene;

    private Player player;

    private void Start()
    {
        currentHealth = maxHealth;
        player = GetComponent<Player>();
    }

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
        if (player != null)
            player.healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
            Destroy(gameObject);

    }

    public void Healing(int bonusHealth)
    {
        currentHealth += bonusHealth;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        if (player != null)
            player.healthBar.SetHealth(currentHealth);
    }
}
