using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShakeHandler : MonoBehaviour
{
    public float duratoin;
    public AnimationCurve Anim;
    
   

public IEnumerator ScreenShakeSmall()
   {
    print("SHAKE!!!");
    Vector3 startpos = transform.position;
    float Timer = 0;

    while (Timer < duratoin)
    {
        Timer += Time.deltaTime; 
        float Streangth = Anim.Evaluate(Timer / duratoin);

        transform.position = startpos + Random.insideUnitSphere * Streangth / 2;
        yield return null;
    }
    transform.position = startpos;
   }

   public void StartScreenShakeSmall()
   {
    StartCoroutine(ScreenShakeSmall());
   }


  public IEnumerator ScreenShakeNormal()
   {
    print("SHAKE!!!");
    Vector3 startpos = transform.position;
    float Timer = 0;

    while (Timer < duratoin)
    {
        Timer += Time.deltaTime; 
        float Streangth = Anim.Evaluate(Timer / duratoin);

        transform.position = startpos + Random.insideUnitSphere * Streangth;
        yield return null;
    }
    transform.position = startpos;
   }

   public void StartScreenShakeNormal()
   {
    StartCoroutine(ScreenShakeNormal());
   }



// hard screenshake
 public IEnumerator ScreenShakeHard()
   {
    print("SHAKE!!!");
    Vector3 startpos = transform.position;
    float Timer = 0;

    while (Timer < duratoin)
    {
        Timer += Time.deltaTime; 
        float Streangth = Anim.Evaluate(Timer / duratoin);

        transform.position = startpos + Random.insideUnitSphere * Streangth * 2.5f;
        yield return null;
    }
    transform.position = startpos;
   }

   public void StartScreenShakeHard()
   {
    StartCoroutine(ScreenShakeHard());
   }
}

