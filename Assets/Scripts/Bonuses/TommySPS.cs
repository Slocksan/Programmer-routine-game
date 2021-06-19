using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TommySPS : MonoBehaviour
{
    public int spdBonus = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var shooting = other.gameObject.GetComponent<Shooting>();
            shooting.lightShotsPerMinute += spdBonus;
            Destroy(gameObject);
        }
    }
}
