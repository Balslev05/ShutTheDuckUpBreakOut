using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using UnityEngine.UI;
public class bossSystem : MonoBehaviour
{
    public Image HealthUI;
    public CinemachineVirtualCamera Player_Camera;
    public Animator Boss_Anim;
    public int BattelCamZoom;
    public int FinderRange;
    public int TimeBetweenAttack;
    public bool ReadyToAttack = false;
    public bool Attacking;
    public float BossSpeed;
    public int BossAttack;
    
    private Health BossHealth;
    private GameObject player;
    private Vector3 NormalSize;
    private Vector3 movement;
    public Vector3 dir;





    [Header ("Attack 1/ Egg")]
    public screenShakeHandler screenShake;
    public GameObject EGG;
    public int FlyHieght;
    public ParticleSystem Partical_Feathers;


    [Header ("Attack 2 / Jump")]
    public Vector3 InAirSize;
    public float LaunchSpeed;
    public GameObject DangerSign;
    public GameObject DangerSignPlacement;
    public bool FoundFinalPoint;
    private GameObject DangerSignPrefab;
    

    [Header ("Attack 3 / Healing")]
    public GameObject BossHealtPotion;
    public int HowManyHeals;
    public int GainHealth;


    [Header ("Introduction")]
    public bool Introduction = false;
    public GameObject Introduction_BossCamera;
    public GameObject Introduction_PlayerCamera;
    public GameObject playersLight;
    public GameObject BossBundary;
    public GameObject BossIntroductionBoundary;

    [Header ("SoundDesign")]
    public AudioSource walking;
    public AudioSource jumping;
    public AudioSource flying;
    public AudioSource EggCraking;


    void Start()
    {
        BossHealth = this.gameObject.GetComponent<Health>();

        player = GameObject.FindGameObjectWithTag("Player");

        NormalSize = transform.localScale;

        BossBundary.SetActive(false);

    }

    void Update()
    {
        
        HealthUI.fillAmount = BossHealth.currentHealth / 100;








        if(movement.x < 0)
        {
           this.gameObject.GetComponent<SpriteRenderer>().flipX = false;  
        }
         if(movement.x > 0)
        {

           this.gameObject.GetComponent<SpriteRenderer>().flipX = true;  
        }


        if(Attacking == false && Introduction == true)
        {


             dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir.Normalize();
            movement = dir;
            
            transform.position = Vector3.MoveTowards(transform.position,player.transform.position, BossSpeed *Time.deltaTime);
            Boss_Anim.Play("BossRuning");
            

        }

        if(Vector2.Distance(transform.position,player.transform.position) < FinderRange * 10)
        {
            if(Introduction == true && Vector2.Distance(transform.position,player.transform.position)< FinderRange * 100) // looking if the intrroduction have been played if not it starts the introduction
            {
                FoundPlayer();
            }
            else
            {
                StartBossIntroduction();
            }
        }
    }
    public void FoundPlayer()
    {
        DOVirtual.Float( Player_Camera.m_Lens.OrthographicSize, BattelCamZoom, 2, LensZoomOut =>{Player_Camera.m_Lens.OrthographicSize = LensZoomOut;}).SetEase(Ease.OutCubic);

        if(ReadyToAttack == true)
        {
        StartCoroutine(BossWaitingToAttack());
        }
    }
    IEnumerator BossWaitingToAttack()
    {

   
        yield return new WaitForSeconds(TimeBetweenAttack);

        if(ReadyToAttack == true)
        {
            AttackPlayer();
        }

   }
    public void AttackPlayer()
    {               
        BossAttack = Random.Range(1,3);
        
        Attacking = true;
        
        if(HowManyHeals == 1 && ReadyToAttack == true && BossHealth.currentHealth < 50)
        {
            BossAttack = 3;
        } 
        
        Attack(BossAttack);

        
    }

    public void Attack(int attackNumber)
    {
        Boss_Anim.Play("Attack" + attackNumber);


        ReadyToAttack = false;
    }

    public void FinishAttack()
    {
        ReadyToAttack = true;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        Attacking = false;

        BossAttack = 0;

    }
    

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            collider.gameObject.GetComponent<Health>().PlayerTakeDamage(2);
        }
    }


    
    //Attack 1
    public void FlyUp()
    {
        transform.DOMoveY(transform.position.y + FlyHieght, 2);
        screenShake.StartShake(0.2f,3,3);       
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

    }
    public void Flydown()
    {  
       transform.DOMoveY(transform.position.y - FlyHieght, 2);
    }
    public void SpawnEGG()
    {
        Instantiate(EGG, transform.position, this.gameObject.transform.rotation);
    }
     public void SpawnFeathers()
    {
        Instantiate(Partical_Feathers, transform.position, this.gameObject.transform.rotation);
        screenShake.StartShake(0.3f,5,3);
    }
    
    
    //Attack 2
    public void Jump()
    {
        transform.DOScale(InAirSize,1f).SetEase(Ease.InOutSine);
        screenShake.StartShake(0.1f,1,1);

        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        
    }
     public void FindigPlayerPos()
    {
         DangerSignPrefab = Instantiate(DangerSign,player.transform.position,Quaternion.identity);

        
        DangerSignPlacement = DangerSignPrefab;
        StartCoroutine(updatingDangerPos());
    }
    IEnumerator updatingDangerPos()
    {
        for (int i = 0; i < 250; i++)
        {
        
        DangerSignPrefab.transform.position = player.transform.position;
        yield return new WaitForSeconds(0.01f);
        }
    }

     public void ChargeAtplayer()
    {
        transform.DOScale(InAirSize,1f);
        transform.DOScale(NormalSize,1);
        // MakeParticals
        transform.DOLocalMove(DangerSignPlacement.transform.position,LaunchSpeed).SetEase(Ease.InOutCubic);

        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        
        Destroy(DangerSignPlacement,2);
        
    }
   
    //Attack 3 aka healing
    public void ChargesToHeal()
    {
        HowManyHeals--;
        BossHealtPotion = Instantiate(BossHealtPotion,transform.position, Quaternion.identity);
        BossHealtPotion.GetComponent<BossHealingPot>().Up();
        BossHealtPotion.transform.parent = this.gameObject.transform;
    }
     public void BeginsToHeal()
     {
        BossHealtPotion.GetComponent<BossHealingPot>().Down();
        StartCoroutine(BossHealing());
     }
     private IEnumerator BossHealing()
     {
        for (int i = 0; i < GainHealth * 2 ; i++)
        {
            BossHealth.currentHealth += 0.5f;
        yield return new WaitForSeconds(0.05f);
        }
     }
    
    
    
    
    // introduction's

    public void StartBossIntroduction()
    {
        Boss_Anim.Play("Introduction");

        Introduction_BossCamera.SetActive(true);
        Introduction_PlayerCamera.SetActive(false);
        
        BossBundary.SetActive(true);
    }
    public void EndBossIntroduction()
    {
        Introduction = true;

        
        Introduction_BossCamera.SetActive(false);
        Introduction_PlayerCamera.SetActive(true);

        BossIntroductionBoundary.SetActive(false);
    }


}
