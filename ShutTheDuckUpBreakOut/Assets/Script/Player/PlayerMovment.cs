using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMovment : MonoBehaviour
{
    public float speed = 250;
    public Rigidbody2D rb;
    public Animator playerAnim;

    [Header("RoleStats")]
    public float RoleLeanght = 1f;
    public float RoleForce = 750f;
    public bool Roling;
    private  Vector2 lastDirection;
    private float NormalMoveSpeed;
    UnityEngine.Vector2 Movement;

    [Header("Walking")]
    public GameObject WalkDust;
    public GameObject Feet;
    
  private void Awake() {
   
  }
    
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

        }else
        {
            Movement.x = Input.GetAxisRaw("Horizontal");
            Movement.y = Input.GetAxisRaw("Vertical");
        }
        
        Vector2 velocity = rb.velocity;   

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(velocity.x != 0 || velocity.y != 0)
            StartCoroutine(Roll());
        }
        
        if(velocity.x == 0 && velocity.y == 0)
        {
            playerAnim.Play("Idle");
        } else
        {
            playerAnim.Play("Running");
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

     public void SpawnDust()
     {
       GameObject dust = Instantiate(WalkDust,Feet.transform.position,Quaternion.identity);
       Destroy(dust,3f);

     }
}

