using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using static TMPro.TextMeshProUGUI;
public class JumperController : MonoBehaviour
{
    public bool isRunning;
    private Rigidbody2D rb;
    private Transform transform;
    private SpriteRenderer sr;
    public float movementSpeed;
    public float jumpSpeed;
    public float scale;
    public bool inAir;
    public int score;
    public float yPos;
    private AudioSource asource;
    private bool spawned;
    private float waitForCheck;
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waitForCheck = 1f;
        spawned = false;
        gameObject.SetActive(true);
        isRunning = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        transform = gameObject.transform;
        yPos = 5;
        asource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        waitForCheck = waitForCheck - Time.deltaTime;
        yPos = transform.position.y;

        if(rb.linearVelocityY != 0f || (rb.linearVelocityY >= 0.19f && rb.linearVelocityY <= 0.21f))
        {
            //inAir = true;
        }
        else
        {
            //inAir = false;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            rb.linearVelocity = new Vector2(-movementSpeed, rb.linearVelocity.y);
            sr.flipX = true;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            rb.linearVelocity = new Vector2(movementSpeed, rb.linearVelocity.y);
            sr.flipX = false;
        }

        if (Keyboard.current.wKey.wasPressedThisFrame & !inAir)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            score += 4;
            asource.Play();
        }
        if(waitForCheck <= 0 && yPos <= -4.5)
        {
            checkDead();
        }

        
        
    }
    void OnCollisionEnter2D(Collision other)
    {
       if(other.gameObject.CompareTag("Platform"))
        {
            score += 2;
            inAir = false;
            if(other.gameObject.GetComponent<PlatformController>().landed == false)
            {
                score += 5;
                other.gameObject.GetComponent<PlatformController>().landed = true;
            }
            
        } 
    }

    private void checkDead()
    {
        if (yPos <= (0 - 4.5)){}
        {
            SceneManager.LoadScene("gameOver");
            gameObject.SetActive(false);
        }
    }
    void OnCollisionStay2D(Collision other)
    {
        if(other.gameObject.CompareTag("Platform"))
        {
            inAir = false;
        }
    }
    void OnCollisionExit2D(Collision other)
    {
        if(other.gameObject.CompareTag("Platform"))
        {
            inAir = true;
        }
    }


}
