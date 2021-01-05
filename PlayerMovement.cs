using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    public float speed = 2.0f;
    public float horizMovement;
    
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizMovement = Input.GetAxisRaw("Horizontal");
        Fixedupdate();
    }

    private void Fixedupdate()
    {
        rb2D.velocity = new Vector2 (horizMovement * speed, rb2D.velocity.y);
    }

}
