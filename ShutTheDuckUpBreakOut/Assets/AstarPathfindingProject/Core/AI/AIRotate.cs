using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRotate : MonoBehaviour
{
        private GameObject player;
    	public Vector3 dir;
    	private Vector3 movement;
        
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player"); 
        }
        void Update()
        {
        
     	    dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir.Normalize();
            movement = dir; 

            if(movement.x < 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;  
            }
            if(movement.x > 0)
            {
                
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;  
            }

        }

    
}