using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Enemies.Pathfinding;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player;
    public int HP;
    public float speed;
    public float distanceOfView;
    public Vector2 topLeftBorder;
    public Vector2 bottomRightBorder;

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

        var hit = Physics2D.Raycast(rb.transform.position, direction.normalized);

        if (false)
        {
            Debug.Log(hit.transform.name);
            moveDirection = direction.normalized;
            rb.rotation = angle;
        }
        else
        {
            var targetPoint = PathfinderAStar
                .FindPath(topLeftBorder, bottomRightBorder, 
                    rb.transform.position, player.transform.position).First();
            Vector2 directionToTarget = (targetPoint - (Vector2)transform.position);
            
            moveDirection = directionToTarget.normalized;
            rb.rotation = Mathf.Atan2(directionToTarget.x, directionToTarget.y) * Mathf.Rad2Deg;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + 
                        moveDirection * speed * Time.fixedDeltaTime);
    }
}
