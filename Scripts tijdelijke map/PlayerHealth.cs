using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{



    // reguleert de health van de speler en Spawning


    //health
    public int maxHealth = 10;
    public int health;

    //spawn
    private Vector3 SpawnIn;
    private Vector3 Respawn;




    void Start()
    {
        health= maxHealth;
        Respawn = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Checkpoint")
        {
            SpawnIn = transform.position;
            Debug.Log("Check");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Thread.Sleep(1000);
        transform.position = SpawnIn;
        if(health <= 1)
        {

            transform.position = Respawn;
        }
    }
}
