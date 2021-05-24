using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = new Rigidbody2D();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));
        var mousePosition = Input.mousePosition;
        transform.LookAt(rb., mousePosition);
    }
}
