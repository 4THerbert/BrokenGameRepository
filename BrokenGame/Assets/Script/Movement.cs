using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // Pass movement state or speed magnitude to the Animator
        // If using a float parameter named "Speed":
        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        // Optional: If using a bool parameter named "IsMoving":
        // anim.SetBool("IsMoving", moveInput != 0f);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}