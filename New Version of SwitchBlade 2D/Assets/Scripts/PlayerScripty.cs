using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerScripty : MonoBehaviour
{
    // variable initialization
    Vector2 moveInput;
    Vector2 jumpForce;
    Rigidbody2D playerRB;
    Collider2D crash;
    int jumpsUsed;
    int maxJumps;
    string playerState;
    public float Jumpy = 1;
    public float Speed = 4;
    //Variables I use to track my state
    public bool OnGround = false;
    public bool FacingLeft = false;
    //If this is over 0, I'm stunned and can't move
    public float Stunned = 0;
    public woodslash woodswordattack;
    public Transform woodensword;
    public pizzaslash pizzabladeattack;
    public Transform pizzacutter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // establish variables
        playerRB = GetComponent<Rigidbody2D>();
        jumpsUsed = 0;
        maxJumps = 2;
        jumpForce = new Vector2(0f, 6.5f);
    }
    public bool CanJump()
    {
        return OnGround;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(0, playerRB.linearVelocity.y);
        OnGround = true;
        // alter player's lateral velocity according to vector and speed values
        //If I hold the right arrow key, the player should move right. . .
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            vel.x = Speed;
            FacingLeft = false;
        }
        //If I hold the left arrow, the player should move left. . .
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            vel.x = -Speed;
            FacingLeft = true;
        }
        //If I hold the up arrow, the player should move up. . .
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = Jumpy;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(woodswordattack, woodensword.position, transform.rotation);
        }
        if (Input.GetButtonDown("Pizza Reflect"))
        {
            Instantiate(pizzabladeattack, pizzacutter.position, transform.rotation);
        }
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
    void OnCollisionEnter2D(Collision2D other)
    {
       Golpozt GOAL = other.gameObject.GetComponent<Golpozt>();
       if (other.gameObject.CompareTag("GOAL"))
{
SceneManager.LoadScene("Level 1 Win");

}

    }
void OnCollisionEnter2D(Collision2D crash)
        // if the collided object was a platform, refresh the player's available jumps
        if (crash.gameObject.CompareTag("Platform"))
        {
            jumpsUsed = 0;
        }
    }

    // activate things while player is crouching (might need to rework this)
    void OnPlayerCrouch(InputValue v)
    {
        if (v.isPressed)
        {
            // if grounded, flag crouch state. if airborne, aim down (WIP)
        }
        else
        {
            // if grounded, flag standing state. if airborne, aim straight (WIP)
        }
    }

    // move player in response to input
    void OnPlayerMove(InputValue v)
    {
        moveInput = v.Get<Vector2>();
    }
}
