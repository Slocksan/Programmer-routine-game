using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreackGunDmgBonus : MonoBehaviour
{
    public int dmgBonus = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var shooting = other.gameObject.GetComponent<Shooting>();
            shooting.heavyGunDamageBonus += dmgBonus;
            Destroy(gameObject);
        }
    }
}
