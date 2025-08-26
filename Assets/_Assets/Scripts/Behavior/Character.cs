using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement settings")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    
    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private int jumpCount;
    private int maxJumpCount = 2;
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
            jumpCount = 0;
        
        moveInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
}
