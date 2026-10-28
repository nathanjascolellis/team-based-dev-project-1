using UnityEngine;

public class pizzaslash : MonoBehaviour
{
    public float MovementSpeed = 1;


    // Update is called once per frame
    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * MovementSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
