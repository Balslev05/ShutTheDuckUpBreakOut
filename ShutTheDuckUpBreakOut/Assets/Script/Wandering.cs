using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
  
    
    public Transform[] waypoints;

  
     Vector3 LastPos;
     Vector3 CurrentPos;
    public float moveSpeed = 2f;


    public GameObject Duck;

    public bool Statinary;
    public bool flip;
	
    private int waypointIndex = 0;
	private void Update () 
    {
        if(Statinary == true)
        {
            if(Duck.GetComponent<Enemy1Ai>().Injail == true)
            {
                Duck.GetComponent<Animator>().Play("EnemyIdleJail");
            } else
            {
                Duck.GetComponent<Animator>().Play("EnemyIdle");
            }

            if(flip == true)
            {
                Duck.GetComponent<SpriteRenderer>().flipX = true;  
            } else
            {
                Duck.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        LastPos = CurrentPos;
        CurrentPos = transform.position;
        
        if(CurrentPos.x > LastPos.x)
        {
            Duck.GetComponent<SpriteRenderer>().flipX = true;  
        }
        if ( CurrentPos.x < LastPos.x){
            Duck.GetComponent<SpriteRenderer>().flipX = false;  

        }

        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
        Move();
	}
	private void Start () 
    {
        Duck.transform.position = waypoints[waypointIndex].transform.position;
        this.gameObject.transform.DetachChildren();
	}
	



    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            Duck.transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

        
            if (Duck.transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}

