using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player;
    public int HP;
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        rb.rotation = angle;
        moveDirection = direction.normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + 
                        moveDirection * speed * Time.fixedDeltaTime);
    }
}
