using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Public Vars")]
    [SerializeField] public float jumpForce;
    [SerializeField] public bool grounded;
    private Rigidbody2D rb;

    [Header("Private Vars")]
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, radOCircle, whatIsGround);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundcheck.position, radOCircle);
    }
}
