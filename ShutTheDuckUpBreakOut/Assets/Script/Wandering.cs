using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
  
    
    public Transform[] waypoints;

  
     Vector3 LastPos;
     Vector3 CurrentPos;
    public float moveSpeed = 2f;

    
    private int waypointIndex = 0;

    public GameObject Duck;

	
	private void Update () 
    {
        LastPos = CurrentPos;
        CurrentPos = transform.position;
        if(CurrentPos.x > LastPos.x)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;  
        }
        if ( CurrentPos.x < LastPos.x){
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;  

        }

        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
            print("Reset");
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

