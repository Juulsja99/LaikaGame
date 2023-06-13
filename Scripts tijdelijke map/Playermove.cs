using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    //move
    private float horizontal;
    private float speed = 20f;
    private float jumpingPower = 16f;
    private float jumpinpowerReverse = -16;
    private bool isFacingRight = true;

    //gravit
    private bool GravityOn = false;
    private bool top;
    //Om gravity aan te zetten, maak 2 empty game objects met triggers
    // Geef 1 de tag TriggerON en de ander TriggerOFF
    //Plaats de TriggerOn op het punt waar je de gravity aan wilt en de TriggerOFF waar je de gravity uit wilt
    



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);


        if (top == false) 
        {
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }


            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
            }

            Flip();
        }

        if (top == true)
        {
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpinpowerReverse);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
            }

            FlipReversed();

            
        }

         
       if(GravityOn == true)    
       {
            if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded())
            {
                rb.gravityScale *= -1;
                Rotation();

            }
       }



       
    }

    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }

        top = !top;
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void FlipReversed()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            
            Vector3 localScale = transform.localScale;
            localScale.x *= 1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "TriggerON")
        {
            Debug.Log("Trigger");
            GravityOn = true;
        }

        if (other.gameObject.tag == "TriggerOFF")
        {
            Debug.Log("OFF");
            GravityOn = false;
        }


    }
}
