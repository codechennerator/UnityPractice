using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {

    public float SPEED = 5f;
    public float JUMP_SPEED = 5f;
    public Transform groundCheckPoint; //A Transform is any object in the scene that can have a position/rotation/scale.
    public float groundCheckRadius;
    public LayerMask groundLayer; //What should the player be able to jump off of?
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;

    private float movement = 0f;
    private Rigidbody2D rigidBody;
    private bool isTouchingGround;
    private Animator playerAnimation; 

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>(); //Makes it so that you don't have to select Rigidbody2D
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
    // Unity has an input manager to find what keys are being input.
	void Update () {
        /*
         * Overlap circle takes in (Vector2 point, float radius, int layerMask) 
         * If any objects on the ground layer is within the radius on the specified point, will returns true or false.
         */
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);  
        movement = Input.GetAxis("Horizontal"); //Once you GetAxis this movement variable will be positive or negative, depending on whether you're moving left or right.
        if (movement > 0f || movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * SPEED, rigidBody.velocity.y); //Vector2(x movement, y movement); If all you're selecting is y, use rigidBody.velocity.y.
            if (movement > 0f)
            {
                transform.localScale = new Vector2(3f, 3f);
            }
            else if (movement < 0f)
            {
                transform.localScale = new Vector2(-3f, 3f);
            }
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, JUMP_SPEED); 
        }

        //Animations
        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            gameLevelManager.Respawn();
        }
        if (other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
       
    }
}
