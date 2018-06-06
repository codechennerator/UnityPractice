using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {

    public const float SPEED = 5f;
    public const float JUMP_SPEED = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>(); //Makes it so that you don't have to select Rigidbody2D
	}
	
	// Update is called once per frame
    // Unity has an input manager to find what keys are being input.
	void Update () {
        movement = Input.GetAxis("Horizontal"); //Once you GetAxis this movement variable will be positive or negative, depending on whether you're moving left or right.
        if (movement > 0f || movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * SPEED, rigidBody.velocity.y); //Vector2(x movement, y movement); If all you're selecting is y, use rigidBody.velocity.y.
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, JUMP_SPEED); 
        }
	}
}
