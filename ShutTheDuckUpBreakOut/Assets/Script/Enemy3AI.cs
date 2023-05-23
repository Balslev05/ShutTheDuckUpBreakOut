using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy3AI : MonoBehaviour
{
    private float timer;
    public Pathfinding.AIPath AIBrain;
    public float AttackDistance;
    private Animator enemyAnim;
    public Vector3 dir;
    public float SlamColdown;
    private  Vector2 lastDirection;
    private GameObject player;
    public screenShakeHandler screenShake;
    private GameObject MainCameraa;
    [SerializeField] private bool ShouldAttack = false;
    public bool ColdownOff;
    private Vector3 movement;
    private Rigidbody2D rb;
    public GameObject AttackCirle;
    public GameObject ShockWave;
    private GameObject PrefabShockWave;
    public Vector3 AttackCirk;
    private Vector3 NormalAttackCirk;
    public Health health;
    public bool isDead = false;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); 
        enemyAnim = this.gameObject.GetComponent<Animator>();
        MainCameraa = GameObject.FindGameObjectWithTag("MainCamera"); 
       screenShake = MainCameraa.GetComponent<screenShakeHandler>();

        NormalAttackCirk = AttackCirle.gameObject.transform.localScale;

        
    }

    // Update is called once per frame
    void Update()
    {
         if(isDead == true)
        {
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            return;
        }

        if(health.currentHealth <= 0)
        {
            	death();
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < AttackDistance && ColdownOff == true)
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
            }  
    }
    public void ChargeAttack()
    {
        //AttackPoint.SetActive(false); 
        AttackCirle.transform.DOScale(AttackCirk,0.8f).SetEase(Ease.OutBack);  
    }

    public void SpawnAttack()
    {
        PrefabShockWave = Instantiate(ShockWave, AttackCirle.transform.position,Quaternion.identity);
        screenShake.StartShake(0.3f,6,3);       

    }
     public void FinishAttack()
    {
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Destroy(PrefabShockWave);
        StartCoroutine(AttackColdown());
    }
    public void RemoveShockWaveOutline() 
    {
        AttackCirle.transform.DOScale(NormalAttackCirk,0.3f).SetEase(Ease.InBack);
    }
    public IEnumerator AttackColdown()
    {
        print("Start");
        ShouldAttack = false;
        ColdownOff = false;
        yield return new WaitForSeconds(SlamColdown);
        ShouldAttack = true;
        ColdownOff = true;
        print("ends");

    }
    public void death()
    {
        AIBrain.enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        isDead = true;       
        
        GetComponent<Animator>().Play("Enemy3Death");
        Destroy(PrefabShockWave);

        health.enabled = false;
        this.gameObject.GetComponent<Enemy3AI>().enabled=false;

    }
}
