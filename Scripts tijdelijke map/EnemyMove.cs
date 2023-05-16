using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public Transform[] patrolpoints;
    public float moveSpeed;
    public int patrolDestination;


    // Update is called once per frame
    void Update()
    {
      if(patrolDestination == 0)
      {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[0].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolpoints[0].position) <.2f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                patrolDestination = 1;
            }
      }

        if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolpoints[1].position) < .2f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                patrolDestination = 0;
            }
        }


    }
}
