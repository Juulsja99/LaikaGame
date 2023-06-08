using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float horizontal;
    private float speed = 13f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public float KBforce;
    public float KBcounter;
    public float KBtotalTime;
    public bool knockFromRight;


    private bool top;



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpingPower;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = Vector2.up * jumpingPower;
        }

        Flip();


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.gravityScale *= -1;
            Rotation();
        }

        Vector2 jumpDir = Vector2.up;
        if (rb.gravityScale == -1)
        {
            jumpDir = -jumpDir;
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
