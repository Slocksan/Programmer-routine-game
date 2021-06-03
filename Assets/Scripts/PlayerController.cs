using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;
    public Camera camera;

    private Vector2 movementInput;
    private Vector2 mousePositionInput;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = new Vector2(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));
        mousePositionInput = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);

        var lookPoint = (mousePositionInput - rb.position);
        var lookAngle = Mathf.Atan2(lookPoint.y, lookPoint.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = lookAngle;
    }
}
