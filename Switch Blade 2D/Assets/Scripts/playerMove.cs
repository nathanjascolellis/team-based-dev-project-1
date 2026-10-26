using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    // variable initialization
    Vector2 moveInput;
    Vector2 jumpForce;
    Rigidbody2D playerRB;
    int jumpsUsed;
    int maxJumps;
    string playerState;
    float playerSpeed; // used for lateral movement, altered between states
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // establish variables
        playerRB = GetComponent<Rigidbody2D>();
        jumpsUsed = 0;
        maxJumps = 2;
        playerSpeed = 5.0f;
        jumpForce = new Vector2(0f, 6.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // alter player's lateral velocity according to vector and speed values
        playerRB.linearVelocity = new Vector2(moveInput.x*playerSpeed, playerRB.linearVelocity.y);
    }

    // activate jump in response to input
    void OnPlayerJump(InputValue v)
    {
        if (v.isPressed)
        {
            // check if player is grounded or has double jump
            if (jumpsUsed < maxJumps)
            {
                // alter vertical velocity
                playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.y, jumpForce.y);
                jumpsUsed += 1; // increment jump count
            }

        }
    }

    // events that happen when the player collides with something
    void OnCollisionEnter2D(Collision2D c)
    {
        // if the collided object was a platform, refresh the player's available jumps
        if (c.gameObject.CompareTag("Platform"))
        {
            jumpsUsed = 0;
        }
    }

    // activate things while player is crouching (might need to rework this)
    void OnPlayerCrouch(InputValue v)
    {
        if (v.isPressed){
            // if grounded, flag crouch state. if airborne, aim down (WIP)
        } else {
            // if grounded, flag standing state. if airborne, aim straight (WIP)
        }
    }

    // move player in response to input
    void OnPlayerMove(InputValue v)
    {
        moveInput = v.Get<Vector2>();
    }
}
