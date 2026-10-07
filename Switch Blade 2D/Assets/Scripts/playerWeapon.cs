using UnityEngine;
using UnityEngine.InputSystem;

public class playerWeapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSwapWeapon(InputValue v)
    {
        if (v.isPressed){
            Debug.Log("weapon swapped");
            // switch int value of weapon selected (WIP)
        }
    }
}
