using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using System.Linq;

public class Player : MonoBehaviour
{
    public int coinCounter;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce = 8;
    [SerializeField] bool inGround = true;
    [SerializeField] bool jump;
    [SerializeField] Transform rayOrigin;
    [SerializeField] Animator animator;
    [SerializeField] GameManager gameManager;
    [SerializeField] bool airJump;
    [SerializeField] bool shieldActive;
    [SerializeField] GameObject shield;
    [SerializeField] SFXManager sfxManager;

    int liveCounter=2;
    float yPosition;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rayOrigin = gameObject.transform.Find("OrigenRayo");
        animator = gameObject.transform.Find("Character_0").GetComponent<Animator>();
        yPosition = transform.position.y;

    }

    void Update()
    {

        CheckForInput();
        PlayerLanding();

        //Debug.Log(hit.transform.name);
        //Debug.DrawRay(rayOrigin.position, Vector2.down, Color.red);

    }

    void FixedUpdate()
    {

        CheckInGround();

        PlayerJump();
    }

    void CheckForInput()
    {
        if (inGround || airJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                jump = true;
                animator.SetTrigger("Jump");

                if (airJump && inGround==false)
                {
                    airJump = false;
                    sfxManager.PlayAudioSFX("DobleJump");

                }

            }
        }
    }

    void CheckInGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, Vector2.down);

        if (hit.collider != null)
        {

            if (hit.distance < 0.2f)
            {

                inGround = true;
                animator.SetBool("Run", true);

            }

            else
            {
                inGround = false;
                animator.SetBool("Run", false);

            }
        }

        else
        {
            inGround = false;
            animator.SetBool("Run", false);

        }
    }

    void PlayerLanding()
    {
        if (transform.position.y < yPosition)
        {

            animator.SetBool("Landing", true);
        }

        else
        {

            animator.SetBool("Landing", false);

        }

        yPosition = transform.position.y;
    }

    void PlayerJump()
    {

        if (jump)
        {

            jump = false;
            sfxManager.PlayAudioSFX("Jump");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
           
        }
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
         //Debug.Log("Hay colision");

         if (collision.transform.CompareTag("Obstacle"))
         {
            //Debug.Log("Hay colision con obstaculo");
            Destroy(collision.gameObject);

            if (shieldActive)
            {
                shield.SetActive(false);
                shieldActive = false;
                sfxManager.PlayAudioSFX("ShieldBreak");

            }

            else 
            {

                sfxManager.PlayAudioSFX("GameOverHit");


                if (liveCounter== 0)

                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().GameOverScreen();
                    //gameManager.GameOverScreen();
                }

                else 
                {
                    liveCounter--;
                
                }
            }
        }
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Coin"))
        {
            coinCounter++;
            Destroy(collision.gameObject);
            sfxManager.PlayAudioSFX("Coin");

        }

        if (collision.CompareTag("AirJump"))
        {
            airJump = true;
            sfxManager.PlayAudioSFX("PowerUpDobleJump");
            Destroy(collision.gameObject);
            
        }

        if (collision.CompareTag("RubyShield"))
        {
            shieldActive = true;
            sfxManager.PlayAudioSFX("PowerUpShield");
            Destroy(collision.gameObject);
            shield.SetActive(true);
            
        }
    }
}

