﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerSpeed = 10;
    private bool facingRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    
	// Update is called once per frame

	void Update ()
	{
	    PlayerMove();
	}

    void PlayerMove()
    {
        // controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        // animation

        // player direction
        if (moveX < 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == false)
        {
            FlipPlayer();
        }

        // physics
        gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        // jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        // Set boolean so we remember if we're facing right or not
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
}