using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{



    // reguleert de health van de speler 

    public int maxHealth = 10;
    public int health;


    void Start()
    {
        health= maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 1)
        {
            Time.timeScale = 5f;
            SceneManager.LoadScene("Scene1");

        }
    }
}
