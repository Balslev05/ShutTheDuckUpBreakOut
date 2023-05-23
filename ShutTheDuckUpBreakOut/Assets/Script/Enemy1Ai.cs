using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Ai : MonoBehaviour
{
    public Pathfinding.AIPath AIBrain;
    public GameObject AttackPoint;
    private float timer;
    public float AttackDistance;
    private Animator enemyAnim;
    public Vector3 dir;
    public bool Injail;
    private  Vector2 lastDirection;
    private GameObject player;
    [SerializeField] private bool ShouldAttack = false;
    private Vector3 movement;
    private Rigidbody2D rb;
    public bool isDead = false;
    public Health health;
    public int DeathScenario;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); 
        enemyAnim = this.gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isDead == true)
        {
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            return;
        }
        if(health .currentHealth <= 0)
        {
            death();
        }


        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < AttackDistance )
        {   
            ShouldAttack = true;

            if(ShouldAttack == true && isDead == false)
            {
                if(Injail == true)
                {
                    enemyAnim.Play("Enemy1AttackJail");
                } else
                {
                    enemyAnim.Play("Enemy1Attack");
                }
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }   
        
        dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir; 
            
            if(movement.x < 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;  
            }
            if(movement.x > 0 )
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;  
            }
            
        Vector2 Rbdir = rb.transform.position - transform.position;
        Rbdir = Rbdir.normalized;
        lastDirection = Rbdir;
        Vector2 velocity = rb.velocity;   
            
        
            if( ShouldAttack == false)
            {
                if(Injail == true)
                {
                    enemyAnim.Play("Enemy1RunJail");
                } else
                {
                    enemyAnim.Play("Enemy1Run");
                }
            } 

    }
      public void ActivateCollider()
    {
        AttackPoint.SetActive(true);

    }
    public void DeactivateCollider()
    {
        AttackPoint.SetActive(false);
        ShouldAttack = false;
        
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        

    }
    public void death()
    {
        isDead = true;
        AIBrain.enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        DeathScenario = UnityEngine.Random.Range(1,3);

        if(DeathScenario == 3)
        {
            Destroy(gameObject);
        }
        if(Injail == false)
        {
            GetComponent<Animator>().Play("Dead" + DeathScenario);
        } else
        {
            GetComponent<Animator>().Play("JailDead" + DeathScenario);
        }
        

        print("death" + DeathScenario);
        health.enabled = false;
        AttackPoint.SetActive(false);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        this.gameObject.GetComponent<Enemy1Ai>().enabled = false;

    }
}
