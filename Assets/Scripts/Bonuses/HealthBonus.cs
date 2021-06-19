using System;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    public int healingPower = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var health = other.gameObject.GetComponent<Health>();
            health.Healing(healingPower);
            Destroy(gameObject);
        }
    }
}
