using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject Bullet;
    public Transform BulletPosition;
    private float Timer;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 2) 
        {
            Timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(Bullet, BulletPosition.position, Quaternion.identity);
    }
}
