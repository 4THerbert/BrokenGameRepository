using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input (-1 for Left/A, 1 for Right/D, 0 for no input)
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // Set the velocity on the X-axis while keeping the current Y velocity (for gravity/jumping)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}