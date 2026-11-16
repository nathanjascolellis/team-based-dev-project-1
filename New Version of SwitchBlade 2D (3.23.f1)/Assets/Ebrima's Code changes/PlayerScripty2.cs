using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScripty2 : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D playerRB;
    public Rigidbody2D playerBody;
    Collider2D crash;
    int jumpsUsed;
    int maxJumps;
    string playerState;
    public float jumpForce = 10;
    public bool isJumping = false;
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
    public Daggerstab daggerattack;
    public Transform daggerknife;
    public Gunshoots bladeshot;

    public Transform bladegun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // establish variables
        playerRB = GetComponent<Rigidbody2D>();
        jumpsUsed = 0;
        maxJumps = 2;
        //   jumpForce = new Vector2(0f, 6.5f);
    }

    public bool CanJump()
    {
        return OnGround;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();

        if (Input.GetKey(KeyCode.W))
        {
            Instantiate(woodswordattack, woodensword.position, transform.rotation);
        }

        if (Input.GetKey(KeyCode.R))
        {
            Instantiate(pizzabladeattack, pizzacutter.position, transform.rotation);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Instantiate(daggerattack, daggerknife.position, transform.rotation);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Instantiate(bladeshot, bladegun.position, transform.rotation);
        }
    }



    // events that happen when the player collides with something
    //  void OnCollisionEnter2D(Collision2D other)
    //  {
    //     Golpozt GOAL = other.gameObject.GetComponent<Golpozt>();
    //     if (other.gameObject.CompareTag("GOAL"))
    // {
    //  SceneManager.LoadScene("Level 1 Win");
    // }
    // }

    public void Jump()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("jump called");
            playerBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
            isJumping = true;
        }

        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump called");
            playerBody.AddForce(new Vector3(0,  jumpForce, 0), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag  == "Platform")
        {
            if (transform.position.y + 1 < collision.gameObject.transform.position.y)
            {
                isJumping = true;
            }

            if (transform.position.x > collision.gameObject.transform.position.x)
            {
                isJumping = true;
            }

            else
            {
                isJumping = false;
            }
            // isJumping = false;
        }
    }
    private void MovePlayer()
    {
        Vector3 vel = new Vector3(0, playerBody.linearVelocity.y);
	
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x -= Speed; //*Time.deltaTime;
            //facingLeft = false;
           // Flip(facingLeft);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            vel.x +=  Speed; //* Time.deltaTime;
           // facingLeft = true;
            //Flip(facingLeft);
        }

        playerBody.linearVelocity = vel;
        //transform.position = newPos;

    }

}