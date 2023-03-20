using System.IO.Pipes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class bossSystem : MonoBehaviour
{

    public int FinderRange;
    private Health BossHealth;
    private GameObject player;
    public CinemachineVirtualCamera Player_Camera;

    public int BattelCamZoom;
    


    void Start()
    {
        BossHealth = this.gameObject.GetComponent<Health>();

        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,player.transform.position) < FinderRange * 10)
        {
            FoundPlayer();
        }
    }




    public void FoundPlayer()
    {
        DOVirtual.Float( Player_Camera.m_Lens.OrthographicSize, BattelCamZoom, 2, LensZoomOut =>{Player_Camera.m_Lens.OrthographicSize = LensZoomOut;}).SetEase(Ease.OutCubic);


    }

    public void AttackPlayer(){
        int BossAttack;
        BossAttack = Random.Range(0,5);

    
    }


}
