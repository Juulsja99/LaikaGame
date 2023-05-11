using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;

    private Rigidbody2D _rb;
    [SerializeField]
    private float jumpPower;

    [SerializeField]
    private LayerMask canJumpFrom;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector2 dir = new Vector2(0, 0);
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dir += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            dir += new Vector2(1, 0);
        }
        transform.Translate(dir * moveSpeed* Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpPower);
        
    }
}
