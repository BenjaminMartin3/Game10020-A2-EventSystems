using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Float for movement speed
    public float speed = 0.5f;
    private Rigidbody2D rb;

    //  Vector2 for input direction and start position 
    private Vector2 input;
    public Vector2 originPosition; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Setting the start position for later use 
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the axis for the input 
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Normalize to make diagonal movements the same speed as the other directions
        input.Normalize(); 
    }

    private void FixedUpdate()
    {
        // Multiply the input by the speed for the movement
        rb.velocity = input * speed; 
    }
}
