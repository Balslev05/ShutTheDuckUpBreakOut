using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
  
    
    public Transform[] waypoints;

  
    
    public float moveSpeed = 2f;

    
    private int waypointIndex = 0;

    public GameObject Duck;

	
	private void Start () 
    {
        Duck.transform.position = waypoints[waypointIndex].transform.position;
        this.gameObject.transform.DetachChildren();
	}
	

	private void Update () 
    {
        
        Move();
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

