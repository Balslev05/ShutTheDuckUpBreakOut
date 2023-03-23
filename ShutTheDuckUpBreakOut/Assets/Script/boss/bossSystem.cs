using System.Net.Mime;
using System.IO.Pipes;
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
    
    private Health BossHealth;
    private GameObject player;

     [Header ("Attack1")]
     public GameObject EGG;


    [Header ("Introduction")]
    public bool Introduction = false;
    public GameObject Introduction_BossCamera;
    public GameObject Introduction_PlayerCamera;
    

    




    void Start()
    {
        BossHealth = this.gameObject.GetComponent<Health>();

        player = GameObject.FindGameObjectWithTag("Player");


    }

    void Update()
    {
          HealthUI.fillAmount = BossHealth.currentHealth / 100;


        if(Vector2.Distance(transform.position,player.transform.position) < FinderRange * 10)
        {
            if(Introduction == true) // looking if the intrroduction have been played if not it starts the introduction
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
        int BossAttack;
        
        BossAttack = Random.Range(1,4);

        Attack(BossAttack);
        
    }

    public void Attack(int attackNumber)
    {
        Boss_Anim.Play("Attack"+attackNumber);

        print(attackNumber);

        ReadyToAttack = false;
    }

    public void FinishAttack()
    {
        ReadyToAttack = true;
    }


    public void SpawnEGG()
    {
        Instantiate(EGG, transform.position, this.gameObject.transform.rotation);
    }

    // introduction's

    public void StartBossIntroduction()
    {
        print("start1");
        Introduction_BossCamera.SetActive(true);
        Introduction_PlayerCamera.SetActive(false);

        Boss_Anim.Play("Introduction");
        print("start2");

    }
    public void EndBossIntroduction()
    {
        Introduction = true;
        print("End1");

        Introduction_BossCamera.SetActive(false);
    
        Introduction_PlayerCamera.SetActive(true);
        print("End2");

    }


}
