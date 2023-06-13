using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackSave : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    private float speed = 9f;
    public float KBforce;
    public float KBcounter;
    public float KBtotalTime;
    public bool knockFromRight;

    [SerializeField] private Rigidbody2D rb;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

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




}
