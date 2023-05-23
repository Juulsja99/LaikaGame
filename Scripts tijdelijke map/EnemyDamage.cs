using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // dit script zorgt ervoor de de speler damage krijgt als deze tegen de enemy aanloopt.

    public int damage;
    public PlayerHealth playerhealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            playerhealth.TakeDamage(damage);
        }
    }
}
