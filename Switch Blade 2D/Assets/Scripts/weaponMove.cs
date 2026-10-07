using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponMove : MonoBehaviour
{
    // variable initialization
    public GameObject playerChar; // assign a player character to the weapon in inspector
    public GameObject weaponObj; // intended to be assigned to the weapon itself
    float xOffset; // determines the offset of the weapon sprite from the player sprite
    bool isFacingRight; // binary direction indicator
    Vector2 weaponPos; // maybe unnecessary but i dont like writing a new vector directly into position
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xOffset = 0.4f;
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        // weapon follows the player, with an offset based on direction
        if (isFacingRight)
        {
            weaponPos = new Vector2(playerChar.transform.position.x + xOffset, playerChar.transform.position.y);
        } else {
            weaponPos = new Vector2(playerChar.transform.position.x - xOffset, playerChar.transform.position.y);
        }
        weaponObj.transform.position = weaponPos;
    }

    // this and the subsequent function allow user input to control facing direction
    void OnFaceLeft(InputValue v)
    {
        if (v.isPressed){
            isFacingRight = false;
            Debug.Log(isFacingRight);
        }
    }

    void OnFaceRight(InputValue v)
    {
        if (v.isPressed){
            isFacingRight = true;
            Debug.Log(isFacingRight);
        }
    }
}
