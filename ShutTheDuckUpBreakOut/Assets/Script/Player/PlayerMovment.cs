using System.Runtime.Serialization.Formatters;
using System.Runtime.InteropServices;
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
    private Player PlayerMechanics;
     Vector2 PlayerNormalScale;

    

    [Header("RoleStats")]
    public float RoleLength = 1f;
    public float RoleForce = 750f;
    public bool Rolling;
    private  Vector2 lastDirection;
    private float NormalMoveSpeed;
    Vector2 Movement;
    public Vector3 RoleHight;

    [Header("Walking")]
    public GameObject WalkDust;
    public GameObject Feet;
    
  private void Awake() {
   
  }
    
    void Start()
    {
        PlayerNormalScale = transform.localScale;

        NormalMoveSpeed = speed;
        rb.GetComponent<Rigidbody2D>();
       PlayerMechanics = this.gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMechanics.CarryingGun! && PlayerMechanics.CarryingMelee!)
        {
            print("yeas");
        } 
        //  Moving 
        Vector2 dir = rb.transform.position - transform.position;
        dir = dir.normalized;
        lastDirection = dir;

        if(Rolling == true)
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
        
        if(!InPrison && velocity.x == 0 && velocity.y == 0)
        {
            if(!PlayerMechanics.CarryingItem)
            {
                playerAnim.Play("idleArms");
            } 

            if(PlayerMechanics.CarryingItem)
            {
                playerAnim.Play("idleAnim");
            }
            
        } else if (!InPrison && velocity.x != 0 ||!InPrison && velocity.y != 0 )
        {
            if(!PlayerMechanics.CarryingItem)
            {
                playerAnim.Play("walkingArms");
            }  

            if(PlayerMechanics.CarryingItem)
            {
                playerAnim.Play("walking"); 
            }
        }
       
        if( InPrison && velocity.x == 0 && velocity.y == 0)
        {
           if(!PlayerMechanics.CarryingItem)
            {
                playerAnim.Play("JailIdleAnimArms");

            } 
            if(PlayerMechanics.CarryingItem)
            {
                playerAnim.Play("JailIdleAnim");

            }
            
        } else if ( InPrison && velocity.x != 0 || InPrison && velocity.y != 0)
        {
            if(!PlayerMechanics.CarryingItem)
            {
                playerAnim.Play("JailWalkingArms");

            } 
            if(PlayerMechanics.CarryingItem)
            {
                playerAnim.Play("JailWalking");
            }
        }
    }
     IEnumerator Roll()
     {
       
        WeaponManager.SetActive(false);
        Rolling = true;
        speed = speed + RoleForce;
        DOVirtual.Float( speed, 0, RoleLength, RollingSpeed =>{speed = RollingSpeed;});
        rb.AddForce(lastDirection * speed); 

      

        //change tag so it cannot be hit
        yield return new WaitForSeconds(RoleLength);

        WeaponManager.SetActive(true);

        Rolling = false;  

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

