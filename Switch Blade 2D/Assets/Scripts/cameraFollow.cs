using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject camera; // intended to be assigned to the camera itself
    public GameObject player; // intended to be assigned to the player character in level
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is too far away, the camera follows
        if (player.transform.position.x - camera.transform.position.x > 2f)
        {
            // moves camera forward in the x direction
            camera.transform.Translate(0.1f, 0f, 0f);
        }
        if (camera.transform.position.x - player.transform.position.x > 6f)
        {
            // moves camera backward in the x direction
            camera.transform.Translate(-0.1f, 0f, 0f);
        }
        if (player.transform.position.y - camera.transform.position.y > 4f)
        {
            // moves camera up
            camera.transform.Translate(0f, 0.1f, 0f);
        }
        if (camera.transform.position.y - player.transform.position.y > 1f)
        {
            // moves camera down
            camera.transform.Translate(0f, -0.1f, 0f);
        }
    }
}
