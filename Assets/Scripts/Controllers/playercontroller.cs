using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using UnityEngine.SceneManagement;


public class playercontroller : MonoBehaviour
{
   
   
    public float speed;
    public float jumpForce;
    public int jumptimes;
    public int health;
    private float moveInput;
    private bool facingRight = true;
    private bool jumpPressed;
    private bool IsGrounded;
    private int extrajumps;
    public Transform groundCheck;
    public GameObject PlayerDeathEffect;
    public GameObject SceneChanger;
    public float checkradius;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject healthtext;
    public AudioSource jump;
    public AudioSource playerdeathsound;
    public AudioSource playerhurtsound;
    public AudioSource playerohnosound;
    public AudioSource playerwalking;
    public ParticleSystem dust;
   

    //Starting Functions

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health += GameDataManager.extralife;
        jumptimes += GameDataManager.extrajump;
        extrajumps = jumptimes;
    }


    //Fixed Updates

    void FixedUpdate()
    {
       
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, checkradius, whatIsGround);
        animator.SetFloat("velocityX", Mathf.Abs(moveInput));
        animator.SetBool("IsGrounded", IsGrounded);
        animator.SetBool("takedamage", false);

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (Mathf.Abs(moveInput) > 0 && IsGrounded)
       {
            if (!playerwalking.isPlaying)
            {
                playerwalking.Play();
            }
      }
        else
       {
           playerwalking.Stop();
       }
      


        if (facingRight == false && moveInput > 0)
        {
            facingRight = !facingRight;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (facingRight == true && moveInput < 0)
        {
            facingRight = !facingRight;
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

 
    }

    void Update()
    {
        // take input
        moveInput = CrossPlatformInputManager.GetAxis("Horizontal");
        jumpPressed = CrossPlatformInputManager.GetButtonDown("Jump");
        

        //jumps

        if (IsGrounded)
        {
            extrajumps = jumptimes;
        }

        if (jumpPressed && (extrajumps > 0))
        {
            rb.velocity = Vector2.up * jumpForce;
            CreateDust();
            jump.Play();
            extrajumps--;
        }
        else if (jumpPressed && IsGrounded && (extrajumps == 0))
        {
            rb.velocity = Vector2.up * jumpForce;
            CreateDust();
            jump.Play();
        }

        //Heath
       

        if (health <= 0)
        {
         
                playerohnosound.Play();
                playerdeathsound.Play();
                Destroy(gameObject);
                Instantiate(PlayerDeathEffect, transform.position, Quaternion.identity);
            
        }

    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetBool("takedamage", true);
        playerhurtsound.Play();
        rb.velocity = Vector2.up * jumpForce;
        healthtext.GetComponent<UpdateHealth>().UpdateHealthUI(health);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("healthshot"))
        {

            collider.GetComponent<destroyShots>().Vanish();
            health += 1;
            healthtext.GetComponent<UpdateHealth>().UpdateHealthUI(health);

        }
        if (collider.CompareTag("Pill"))
        {

            collider.GetComponent<destroyPill>().Vanish();
            GameDataManager.pills += 1;
            GameDataManager.UpdatePills();
        }

    }


        public void KillPlayer()
    {
        health = 0;
        healthtext.GetComponent<UpdateHealth>().UpdateHealthUI(health);
    }

    void CreateDust()
    {
        dust.Play();
    }
  
}
