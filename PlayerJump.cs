using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Details")]
    [SerializeField] public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedjumping;
    

    [Header("Ground Details")]
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] public bool grounded;

    [Header("Component")]
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, radOCircle, whatIsGround);

        if(grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        if(Input.GetButtonDown("Jump") && grounded)
        {
            //Jmping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            stoppedjumping = false;
        }

        if(Input.GetButton("Jump") && !stoppedjumping && (jumpTimeCounter > 0))
        {
            //MidJump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }
        if(Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedjumping = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundcheck.position, radOCircle);
    }
}
