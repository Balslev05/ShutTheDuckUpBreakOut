using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoungMechanics : MonoBehaviour
{
       int BulletTimeTime = 2;
    int BTRelode = 10; // BulletTimeRelode
    public bool BulletTimeGoing;
    public bool ChargeSan;
    public bool DrainSan;
    Vector2 startpos;
    public YoungMovment Movement;
    public GameObject TimeScaleFX; 
   //! public Stats stats;
   //! public BulletTimeUI UiRecharg;
    public bool ghostSpawn;
    public float Health;
    public Animator watch;
    public GameObject arms;
   //! public DeathScript dead;
    public float knockbackStrength;
    Rigidbody2D rb;
   [HideInInspector] public bool ArmsActive = false;

    void Start()
    {
        BulletTimeGoing = false;
        startpos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   



        

        //-----Inputs
        //Time
        if(Input.GetKeyDown(KeyCode.LeftShift) && BulletTimeGoing == false)
        {
            StartCoroutine(BulletTime());
        }
        //!health System
       // !stats.Current = Health;
        if(Health <= 0)
        {   
            //dead.Dead();
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(this.gameObject.GetComponent<YoungMovment>());
        }
    }

    
    IEnumerator BulletTime()
    {                           //Time stop begins
        BulletTimeGoing = true;
        ghostSpawn = (true);
        DrainSan = true;
        TimeScaleFX.SetActive(true);
        Debug.Log(Time.fixedDeltaTime);
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = 0.01f;
        Debug.Log(Time.fixedDeltaTime);
        Movement.speed = Movement.speed * 4;
        
        yield return new WaitForSeconds(BulletTimeTime);    // TimeStop Stop
        
        ghostSpawn = (false);
        Movement.speed = 500;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;

        yield return new  WaitForSeconds(0.30f);
        
        TimeScaleFX.SetActive(false);
        StartCoroutine(BulletTimeRelode());
    }
    IEnumerator BulletTimeRelode()
    {
        watch.Play("ClockAnim");
        ChargeSan = true;
        DrainSan = false;
         
        yield return new WaitForSeconds(BTRelode);
        
        BulletTimeGoing = false;
        ChargeSan = false;
    }
    IEnumerator SpeedBoost(){

        Movement.speed = Movement.speed + 200;   

        yield return new WaitForSeconds(2);

        Movement.speed = 500;
    }
    

    void OnCollisionEnter2D(Collision2D other)
    {
        //!health Pickup
        if(other.gameObject.tag == "SpeedBoost")
            {
                StartCoroutine(SpeedBoost());
                Destroy(other.gameObject);
            }
    }
    void OnTriggerEnter2D(Collider2D other) // Registrer attacks on player
    {
            if(Health < 10)
            {
                if(other.gameObject.tag == "Item_Health")
                {
                    Health = Health + 2.5f;
                    Destroy(other.gameObject);
                }           
            }  
            //  if(other.gameObject.CompareTag("EnemyBullet"))
            if(other.gameObject.tag == "EB") // hit wuth enemy bullet
            {
                Health -=2;
            }
            if(other.gameObject.tag == "attackBox") // hit with littel bird attack
            {
                if(Movement.Roling == true){
                    return;
                }
                
                Health -=1.5f * Time.deltaTime;
            }
             if(other.gameObject.tag == "Pistol") // hit with littel bird attack
            {
                if(Movement.Roling == true){
                    return;
                }
               arms.SetActive(true);
               ArmsActive = true;
               Destroy(other.gameObject);
            }
             if(other.gameObject.tag == "AttackBoxHeavy") // hit with Big bird attack
            {
                if(Movement.Roling == true){
                    return;
                }
                Health -=0.2f;
                /* Rigidbody2D rb = this.gameObject.gameObject.GetComponent<Rigidbody2D>();
                Vector2 knockbackDirection = this.gameObject.transform.position - transform.position;
                knockbackDirection.Normalize();
                rb.AddForce(knockbackDirection * knockbackStrength, ForceMode2D.Impulse); */
            }     
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Hole")
            {
                if(Movement.Roling == true)
                {
                    other.gameObject.AddComponent<Collider>();
                    //!other.gameObject.GetComponent<Collider>().collided();
                    
                }
                    
                 
            } 
    }   
}



