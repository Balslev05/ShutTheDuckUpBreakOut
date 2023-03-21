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



    void Start()
    {
        BossHealth = this.gameObject.GetComponent<Health>();

        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
          HealthUI.fillAmount = BossHealth.currentHealth / 100;


        if(Vector2.Distance(transform.position,player.transform.position) < FinderRange * 10)
        {
            FoundPlayer();
        }
    }




    public void FoundPlayer()
    {
        DOVirtual.Float( Player_Camera.m_Lens.OrthographicSize, BattelCamZoom, 2, LensZoomOut =>{Player_Camera.m_Lens.OrthographicSize = LensZoomOut;}).SetEase(Ease.OutCubic);

        StartCoroutine(BossWaitingToAttack());
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

        ReadyToAttack = false;

        print("A " + attackNumber);
    }

    public void FinishAttack()
    {
        ReadyToAttack = true;
        StartCoroutine(BossWaitingToAttack());
    }


}
