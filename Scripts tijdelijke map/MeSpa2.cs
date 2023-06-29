using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeSpa2 : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0, -1, 0);
    public float speed = 1.0f;
    [SerializeField] private float countdown;

    public Instantiate2 bullet;
    public Transform BulletPosition;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {

            Instantiate2 newBullet = Instantiate(bullet, BulletPosition.position, Quaternion.identity);
            newBullet.velocity = velocity;
            newBullet.speed = speed + 5f;
            countdown = 5f;
        }
    }
}
