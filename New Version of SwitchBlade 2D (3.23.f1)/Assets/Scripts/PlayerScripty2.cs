using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScripty2 : MonoBehaviour
{
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
            FacingLeft = false;
        }
        //If I hold the left arrow, the player should move left. . .
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
            FacingLeft = true;
        }
        //If I hold the up arrow, the player should move up. . .
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = Jumpy;
        }
        if(Input.GetKey(KeyCode.S))
        {
            Instantiate(woodswordattack, woodensword.position, transform.rotation);
        }
        if (Input.GetButtonDown("Pizza Reflect"))
        {
            Instantiate(pizzabladeattack, pizzacutter.position, transform.rotation);
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
}