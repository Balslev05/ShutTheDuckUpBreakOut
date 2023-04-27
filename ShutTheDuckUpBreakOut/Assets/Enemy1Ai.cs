using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Ai : MonoBehaviour
{
    public GameObject AttackPoint;
    private float timer;
    public float AttackDistance;
    private Animator enemyAnim;
    public Vector3 dir;
    private  Vector2 lastDirection;
    private GameObject player;
    private bool DoingAttack = false;
    private Vector3 movement;
    private Rigidbody2D rb;



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
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < AttackDistance && DoingAttack == false)
        {  
            DoingAttack = true;
            enemyAnim.Play("Enemy1Attack");
            print("PLZ");
        }
        
            dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir.Normalize();
            movement = dir; 
        
            if(movement.x < 0 && DoingAttack == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;  
            }
            if(movement.x > 0 && DoingAttack == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;  
            }
            
            Vector2 Rbdir = rb.transform.position - transform.position;
            Rbdir = dir.normalized;
            lastDirection = dir;
            Vector2 velocity = rb.velocity;   
            
             if(velocity.x == 0 && velocity.y == 0)
        {
            enemyAnim.Play("Enemy1Run");
        } else
        {
            enemyAnim.Play("Enemy1Run");
        }
    }
      public void ActivateCollider()
    {
        AttackPoint.SetActive(true);
    }
    public void DeactivateCollider()
    {
        AttackPoint.SetActive(false);
        DoingAttack = false;

    }

}
