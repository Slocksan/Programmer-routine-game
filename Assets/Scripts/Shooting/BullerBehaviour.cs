using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Random = UnityEngine.Random;

public class BullerBehaviour : MonoBehaviour
{
    public Sprite[] Sprites;

    public float RicochetChance = 0;

    void Awake ()
    {
        SpriteRenderer bulletSprite = this.GetComponent<SpriteRenderer>();
        if (Sprites.Length > 0)
            bulletSprite.sprite = Sprites[Random.Range(0, Sprites.Length)];
        Destroy (this.gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall") && Random.Range(0f, 1f) > RicochetChance)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy") && Random.Range(0f, 1f) > RicochetChance)
        {
            Destroy(gameObject);
        }
    }
}
