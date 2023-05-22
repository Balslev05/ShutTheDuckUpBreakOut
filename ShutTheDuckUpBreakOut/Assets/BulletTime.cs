using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    public GameObject TimeScaleFX; 
    public bool BulletTimeGoing;
    int BulletTimeTime = 2;
    public bool ChargeSan;
    int BTRelode = 10; // BulletTimeRelode
    public bool ghostSpawn;
    public PlayerMovment Movement;
    public bool DrainSan;

    
    IEnumerator BulletTimeStart()
    {                           //Time stop begins
        BulletTimeGoing = true;
        ghostSpawn = (true);
        DrainSan = true;
        TimeScaleFX.SetActive(true);
        Debug.Log(Time.fixedDeltaTime);
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = 0.01f;
        Debug.Log(Time.fixedDeltaTime);
        Movement.speed = Movement.speed * 4;
        
        yield return new WaitForSeconds(BulletTimeTime);    // TimeStop Stop
        
        ghostSpawn = (false);
        Movement.speed = 500;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;

        yield return new  WaitForSeconds(0.30f);
        
        TimeScaleFX.SetActive(false);
        StartCoroutine(BulletTimeRelode());
    }
     IEnumerator BulletTimeRelode()
    {
        ChargeSan = true;
        DrainSan = false;
         
        yield return new WaitForSeconds(BTRelode);
        
        BulletTimeGoing = false;
        ChargeSan = false;
    }
}
