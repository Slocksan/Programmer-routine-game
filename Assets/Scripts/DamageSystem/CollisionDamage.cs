using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage = 10;
    public string tag;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tag)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(5);
        }
    }
}
