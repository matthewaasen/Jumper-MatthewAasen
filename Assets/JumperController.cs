using UnityEngine;
using UnityEngine.InputSystem;

public class JumperController : MonoBehaviour
{
    public bool isRunning;
    private Rigidbody2D rb;
    private Transform transform;
    public float movementSpeed;
    public float jumpSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isRunning = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            rb.linearVelocity = new Vector2(-movementSpeed, rb.linearVelocity.y);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            rb.linearVelocity = new Vector2(movementSpeed, rb.linearVelocity.y);
        }
    }
}
