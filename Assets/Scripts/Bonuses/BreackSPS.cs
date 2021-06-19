using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreackSPS : MonoBehaviour
{
    public int spdBonus = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var shooting = other.gameObject.GetComponent<Shooting>();
            shooting.heavyShotsPerMinute += spdBonus;
            Destroy(gameObject);
        }
    }
}
