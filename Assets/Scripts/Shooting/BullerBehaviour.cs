using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BullerBehaviour : MonoBehaviour
{
    public Sprite[] Sprites;

    void Awake ()
    {
        SpriteRenderer bulletSprite = this.GetComponent<SpriteRenderer>();
        bulletSprite.sprite = Sprites[Random.Range(0, Sprites.Length)];
        Destroy (this.gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" && Random.Range(0, 5) != 0)
        {
            Destroy(this.gameObject);
        }
    }
}
