using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using UnityEngine.UI;

public class BulletTime : MonoBehaviour
{
    [SerializeField] int BulletTimeTime = 2;
    [SerializeField] int BTRelode = 30; // BulletTimeRelode
    bool timeslowReady;
    public bool timeSlowActiv;
    public PlayerMovment Movement;
    public Guns playerguns;
    public Image overlay;
    public Image TimeBar;
    public CinemachineVirtualCamera Player_Camera;
    float TimeBetweenShotsNormal;
    float TimefillAmount = 1;
    float timeScale = 1;
    float FixedtimeScale = 0.02f;

    public void Update()
    {
        Time.timeScale = timeScale;

        Time.fixedDeltaTime = FixedtimeScale;
        
        TimeBar.fillAmount = TimefillAmount;
        if(Input.GetKeyDown(KeyCode.Q) && timeslowReady == false && Movement.Rolling == false)
        {
            timeSlowActiv = true;
            timeslowReady = true;
            
           StartCoroutine(BulletTimeStart());
        }
    }
    IEnumerator BulletTimeStart()
    {

       TimeBetweenShotsNormal = playerguns.TimeBetweenShots;
        DOTween.To(x => TimefillAmount = x,TimefillAmount,0,BulletTimeTime);

        DOTween.To(x => Movement.speed = x,Movement.speed,2500,1f);
        DOTween.To(x => playerguns.TimeBetweenShots = x,playerguns.TimeBetweenShots,playerguns.TimeBetweenShots/3,0.5f);

        DOVirtual.Float( Player_Camera.m_Lens.OrthographicSize, 4.5f, 0.5f, LensZoomOut =>{Player_Camera.m_Lens.OrthographicSize = LensZoomOut;}).SetEase(Ease.OutCubic);
        overlay.DOFade(0.60f,0.5f);


        DOTween.To(x => timeScale = x,timeScale,0.33f,0.5f);
        DOTween.To(x => FixedtimeScale = x,FixedtimeScale,0.005f,0.5f);
        
        
        yield return new WaitForSeconds(BulletTimeTime);    //! TimeStop Stop
        

        DOTween.To(x => Movement.speed = x,Movement.speed,250,0.5f);
        playerguns.TimeBetweenShots = TimeBetweenShotsNormal;

        DOVirtual.Float( Player_Camera.m_Lens.OrthographicSize, 5.5f, 2, LensZoomOut =>{Player_Camera.m_Lens.OrthographicSize = LensZoomOut;}).SetEase(Ease.OutCubic);
        overlay.DOFade(0,0.5f);


        DOTween.To(x => timeScale = x,timeScale,1f,0.5f);
        DOTween.To(x => FixedtimeScale = x,FixedtimeScale,0.02f,0.5f);
        

        yield return new  WaitForSeconds(0.30f);
        
        timeSlowActiv = false;
        StartCoroutine(BulletTimeRelode());
    }
     IEnumerator BulletTimeRelode()
    { 
        DOTween.To(x => TimefillAmount = x,TimefillAmount,1,BTRelode + 1);
        yield return new WaitForSeconds(BTRelode);
        timeslowReady = false;
    }
        
}
