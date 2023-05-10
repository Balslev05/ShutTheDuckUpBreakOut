using System.Collections;
using UnityEngine;
using DG.Tweening;
public class PlayerMovment : MonoBehaviour
{
    public bool InPrison;
    public float speed = 250;
    public Rigidbody2D rb;
    public Animator playerAnim;
    public GameObject WeaponManager;
    private Player PlayerMechics;
    

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
       PlayerMechics = this.gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerMechics.CarryingGun! && PlayerMechics.CarryingMelee!)
        {
            print("yeas");
        } 

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
            {
                if(InPrison)
                {
                playerAnim.Play("JailRolling");
                } else {playerAnim.Play("Rolling");}

                StartCoroutine(Roll());
            }

        }
        //! NOEL DONT LOOK
        if(!InPrison && velocity.x == 0 && velocity.y == 0)
        {
            playerAnim.Play("idleAnim");
            
        } else if ( !InPrison && velocity.x != 0 ||!InPrison && velocity.y !=0 )
        {
            playerAnim.Play("walking");
        }
       
        if( InPrison && velocity.x == 0 && velocity.y == 0)
        {
            playerAnim.Play("JailIdleAnim");
            
        } else if ( InPrison && velocity.x != 0 || InPrison && velocity.y != 0)
        {
            playerAnim.Play("JailWalking");
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
        yield return new WaitForSeconds(RoleLeanght);

        WeaponManager.SetActive(true);

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

