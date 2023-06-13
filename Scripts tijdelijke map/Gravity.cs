using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool top;
    public float Jumpforce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            rb.gravityScale *= -1;
            Rotation();
            
            

        }

        if (top == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Debug.Log("Jump");
                Debug.Log(gameObject.transform.position);
                rb.AddForce(Vector2.up * Jumpforce);

            }
        }

    }

    void Rotation()
    {
        if(top ==false) 
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else 
        {
            transform.eulerAngles = Vector3.zero;
        }

        top = !top;
    }

    
}
