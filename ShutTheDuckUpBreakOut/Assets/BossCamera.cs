using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;


public class BossCamera : MonoBehaviour
{


    [Header("Targets")]
    public Transform Boss;
    public Transform Player;
    public Transform Mid; // MidPoint

    [Header("Other")]
    public Vector3 MidPoint;
    public CinemachineVirtualCamera cam;
    public bossSystem BossSystme;
    
    // Update is called once per frame
    void Update()
    {
        MidPoint = Vector3.Lerp(Boss.position, Player.position,0.5f);

        this.gameObject.transform.position = MidPoint;  

        
        if(BossSystme.BossAttack == 1 || !BossSystme.Introduction)
        {
            cam.m_Follow = Player;
        } else
        {
            float dist = Vector3.Distance(Player.position,Boss.position);

            cam.m_Lens.OrthographicSize = dist- dist/3;
            cam.m_Lens.OrthographicSize = Mathf.Clamp(cam.m_Lens.OrthographicSize,5,17);

            cam.m_Follow = Mid;
        }
    }
}
