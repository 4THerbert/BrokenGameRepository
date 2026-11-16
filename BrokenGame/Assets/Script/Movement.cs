using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // Flip the sprite based on movement direction
        if (moveInput > 0f)
        {
            spriteRenderer.flipX = true; // Facing right
        }
        else if (moveInput < 0f)
        {
            spriteRenderer.flipX = false; // Facing left
        }

        // Freeze animation if stationary, otherwise play at normal speed
        if (Mathf.Abs(moveInput) > 0f)
        {
            anim.speed = 1f;
        }
        else
        {
            anim.speed = 0f;
        }

        anim.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}