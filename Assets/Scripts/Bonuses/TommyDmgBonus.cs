using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TommyDmgBonus : MonoBehaviour
{
    public int dmgBonus = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var shooting = other.gameObject.GetComponent<Shooting>();
            shooting.lightGunDamageBonus += dmgBonus;
            Destroy(gameObject);
        }
    }
}
