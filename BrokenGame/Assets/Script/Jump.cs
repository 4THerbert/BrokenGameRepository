using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float cooldownTime = 1.5f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private float nextJumpTime = 0f;
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Check if the player is touching the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // 2. Check for input, ground status, and if the cooldown has passed
        if (Input.GetButtonDown("Jump") && isGrounded && Time.time >= nextJumpTime)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply upward velocity instantly using Impulse mode
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        // Set the timestamp for when the player can next jump
        nextJumpTime = Time.time + cooldownTime;
    }

    // Optional: Visualizes the ground check radius in the Unity Editor scene view
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.drawWireSphere(groundCheck.position, checkRadius);
        }
    }
}