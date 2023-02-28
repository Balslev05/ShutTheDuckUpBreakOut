using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int speed = 150;
    public Rigidbody2D rb;
    UnityEngine.Vector2 Movement;
    private float ActiveMoveSpeed;
    public bool Roling;
    public  Vector2 lastDirection;
  
    
    void Start()
    {
        ActiveMoveSpeed = speed;
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

       // if(mechanics.ArmsActive == false)
       /*  {
            anim.SetBool("Gun",false);
        } else{anim.SetBool("Gun",true); } */



        //  Moving 
        Vector2 dir = rb.transform.position - transform.position;
        dir = dir.normalized;
        lastDirection = dir;
        if(Roling == true){
            
            return;
        }
        else{
            Movement.x = Input.GetAxisRaw("Horizontal");
            Movement.y = Input.GetAxisRaw("Vertical");
        }
        Vector2 velocity = rb.velocity;   

        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(velocity.x != 0 || velocity.y != 0)
            StartCoroutine(Roll());
        }
        
       
        
    }
     IEnumerator Roll()
     {
        Roling = true;
        speed = speed - 35;
        rb.AddForce(lastDirection * speed); 
        //change tag so it canoot be hit
        yield return new WaitForSeconds(0.7f);
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        speed = speed + 35;
        Roling = false;  
     }
     private void FixedUpdate() {
        rb.velocity = new Vector2((Movement.x * speed) * Time.deltaTime,(Movement.y * speed) * Time.deltaTime);
     }
}

