using System.Collections.Generic;
using UnityEngine;
using Enemies.Pathfinding;

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
    private bool playerWasInVision = false;


    private PathfinderAStar PathfinderAStar;
    private List<Vector2> trackList;
    private Vector2 currentWayPoint;
    private int indexOfWayPoint = 0;
    private bool isRealToFind = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PathfinderAStar = GetComponent<PathfinderAStar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(rb.position, target.transform.position) < distanceOfView)
        {
            Vector2 direction = target.transform.position - transform.position;
            float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            
            var hit = Physics2D.Raycast(rb.transform.position, direction.normalized);

            if (hit.collider.gameObject == target)
            {
                playerWasInVision = true;
                isRealToFind = true;
                trackList = null;
                indexOfWayPoint = 0;
                moveDirection = direction.normalized;
                rb.rotation = angle;
            }
            else if (playerWasInVision && isRealToFind)
            {
                playerWasInVision = false;
                moveDirection = Vector2.zero;
                trackList = PathfinderAStar
                    .FindPath(topLeftBorder, bottomRightBorder,
                        rb.transform.position, target.transform.position);
                if (trackList == null)
                    isRealToFind = false;

            }
            else if (isRealToFind && trackList == null)
            {
                trackList = PathfinderAStar
                    .FindPath(topLeftBorder, bottomRightBorder,
                        rb.transform.position, target.transform.position);
            }
        }
        else
        {
            moveDirection = Vector2.zero;
            playerWasInVision = false;
            isRealToFind = false;
        }
    }


    private void FixedUpdate()
    {
        if(trackList != null)
        {
            if (trackList.Count > indexOfWayPoint)
            {
                currentWayPoint = trackList[indexOfWayPoint];
                walk();
            }
        }
        else
            rb.MovePosition(rb.position + 
                            moveDirection * speed * Time.fixedDeltaTime);
    }
    
    void walk()
    {
        Vector2 direction = currentWayPoint - (Vector2) rb.transform.position;
        float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        
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
