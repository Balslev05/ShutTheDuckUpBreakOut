using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy3AI : MonoBehaviour
{
    private float timer;
    public float AttackDistance;
    private Animator enemyAnim;
    public Vector3 dir;
    private  Vector2 lastDirection;
    private GameObject player;
    [SerializeField] private bool ShouldAttack = false;
    private Vector3 movement;
    private Rigidbody2D rb;
    public GameObject AttackCirle;
    public GameObject ShockWave;
    private GameObject PrefabShockWave;
    public Vector3 AttackCirk;
    private Vector3 NormalAttackCirk;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); 
        enemyAnim = this.gameObject.GetComponent<Animator>();

        NormalAttackCirk = AttackCirle.gameObject.transform.localScale;

        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < AttackDistance )
        {   
            ShouldAttack = true;

            if(ShouldAttack == true)
            {
            enemyAnim.Play("Enemy3Attack");

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
                enemyAnim.Play("Enemy3Run");
                print("1");
            }  
    }
    public void ChargeAttack()
    {
        //AttackPoint.SetActive(false); 
        AttackCirle.transform.DOScale(AttackCirk,0.5f).SetEase(Ease.Linear);
       
    }

    public void SpawnAttack()
    {
        PrefabShockWave = Instantiate(ShockWave,transform.position,Quaternion.identity);
    }
     public void FinishAttack()
    {
        ShouldAttack = false;
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        Destroy(PrefabShockWave);
    }
    public void RemoveShockWaveOutline() 
    {
        AttackCirle.transform.DOScale(NormalAttackCirk,0.001f).SetEase(Ease.Linear);
    }
}
