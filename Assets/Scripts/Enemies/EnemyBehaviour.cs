using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Enemies.Pathfinding;
using UnityEngine.Serialization;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject target;
    public int HP;
    public float speed;
    public float distanceOfView;
    public Vector2 topLeftBorder;
    public Vector2 bottomRightBorder;

    
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool playerInVision = false;


    private PathfinderAStar PathfinderAStar;
    private List<Vector2> trackList;
    private Vector2 currentWayPoint;
    private int indexOfWayPoint = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PathfinderAStar = GetComponent<PathfinderAStar>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        if (Vector2.Distance(rb.position, target.transform.position) < distanceOfView)
        {
            var hit = Physics2D.Raycast(rb.transform.position, direction.normalized);

            if (hit.collider.gameObject == target)
            {
                playerInVision = true;
                trackList = null;
                indexOfWayPoint = 0;
                moveDirection = direction.normalized;
                rb.rotation = angle;
            }
            else if (playerInVision)
            {
                playerInVision = false;
                moveDirection = Vector2.zero;
                trackList = PathfinderAStar
                    .FindPath(topLeftBorder, bottomRightBorder,
                        rb.transform.position, target.transform.position);
            }
            else if (moveDirection == Vector2.zero)
            {
                trackList = PathfinderAStar
                    .FindPath(topLeftBorder, bottomRightBorder,
                        rb.transform.position, target.transform.position);
            }
        }
        else
        {
            moveDirection = Vector2.zero;
        }
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + 
                        moveDirection * speed * Time.fixedDeltaTime);
        if(trackList != null)
        {
            if(trackList.Count > indexOfWayPoint)
                currentWayPoint = trackList[indexOfWayPoint];
            walk();
        }
    }
    
    void walk(){
        Vector2 direction = currentWayPoint - (Vector2)rb.transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        
        moveDirection = direction.normalized;
        rb.rotation = angle;
        
        rb.MovePosition(rb.position + 
                        moveDirection * speed * Time.fixedDeltaTime);

        if (indexOfWayPoint == trackList.Count)
        {
            indexOfWayPoint = 0;
            trackList = null;
            moveDirection = Vector2.zero;
            return;
        }
        
        if(Vector2.Distance((Vector2)rb.transform.position, currentWayPoint) < 0.1f)
        {
            currentWayPoint = trackList[indexOfWayPoint];
            indexOfWayPoint++;
        }
    } 
}
