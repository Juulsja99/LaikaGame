using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float horizontal;
    private float speed = 20f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public float KBforce;
    public float KBcounter;
    public float KBtotalTime;
    public bool knockFromRight;



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

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

    private void FixedUpdate()
    {

        if (KBcounter <= 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            Debug.Log(KBforce + " " + knockFromRight);
            if (knockFromRight == true)
            {
                rb.velocity = new Vector2(-KBforce, KBforce);

            }
            if (knockFromRight == false)
            {
                rb.velocity = new Vector2(KBforce, KBforce);
            }

            KBcounter -= Time.deltaTime;

        }

    }

    private bool IsGrounded()
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
}