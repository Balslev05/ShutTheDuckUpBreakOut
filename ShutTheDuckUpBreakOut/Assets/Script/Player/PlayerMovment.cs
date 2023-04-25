using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMovment : MonoBehaviour
{
    public float speed = 250;
    public Rigidbody2D rb;
    public Animator playerAnim;
    public GameObject WeaponManager;

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

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(velocity.x != 0 || velocity.y != 0)
            StartCoroutine(Roll());
        }
        
        if(velocity.x == 0 && velocity.y == 0)
        {
            playerAnim.Play("idleAnim");
            
        } else
        {
            playerAnim.Play("walking");
            

        }
    }
     IEnumerator Roll()
     {
       

        WeaponManager.SetActive(false);
        Roling = true;
        speed = speed + RoleForce;
        DOVirtual.Float( speed, 0, RoleLeanght, RolingSpeed =>{speed = RolingSpeed;});
        rb.AddForce(lastDirection * speed); 
        //change tag so it canoot be hit
        playerAnim.Play("Rolling");
        yield return new WaitForSeconds(RoleLeanght);

        WeaponManager.SetActive(true);

        gameObject.GetComponent<Collider2D>().isTrigger = false;

        Roling = false;  

        speed = NormalMoveSpeed;

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

