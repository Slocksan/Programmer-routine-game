using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BullerBehaviour : MonoBehaviour
{
    public Sprite[] Sprites;

    void Awake ()
    {
        SpriteRenderer bulletSprite = this.GetComponent<SpriteRenderer>();
        bulletSprite.sprite = Sprites[Random.Range(0, 5)];
        Destroy (this.gameObject, 5f);
    }
}
