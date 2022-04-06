using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rig;

    private bool facingRight = true;
    private Vector2 moveVector;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
        HandleAnimation();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = moveVector.normalized * moveSpeed; 
        rig.velocity = velocity;
    }
    private void HandleInput()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if(direction.x > 0 && !facingRight || direction.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0);
    }
    private void HandleAnimation()
    {
        anim.SetFloat("Speed", Mathf.Abs(moveVector.x) + Mathf.Abs(moveVector.y));
    }
}
