using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMovment : MonoBehaviour
{

    public float speed = 150;
    public Rigidbody2D rb;
    [Header("RoleStats")]
    public float RoleLeanght = 1f;
    public float RoleForce = 750f;
    public bool Roling;
    private  Vector2 lastDirection;
    private float NormalMoveSpeed;
    UnityEngine.Vector2 Movement;
  
    
    void Start()
    {
        NormalMoveSpeed = speed;
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
        if(Roling == true)
        {
         return;
        }
        else
        {
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
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        Roling = true;
        speed = speed + RoleForce;
        DOVirtual.Float( speed, 0, RoleLeanght, RolingSpeed =>{speed = RolingSpeed;});
        rb.AddForce(lastDirection * speed); 
        //change tag so it canoot be hit

        yield return new WaitForSeconds( RoleLeanght + 0.02f);

        gameObject.GetComponent<Collider2D>().isTrigger = false;

        Roling = false;  
        speed = NormalMoveSpeed;

        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
     }
     private void FixedUpdate() {
        rb.velocity = new Vector2((Movement.x * speed) * Time.deltaTime,(Movement.y * speed) * Time.deltaTime);
     }
}

