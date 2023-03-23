using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShakeHandler : MonoBehaviour
{
    public float duratoin;
    public AnimationCurve Anim;
    
   

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

   public void StartScreenShake()
   {
    StartCoroutine(ScreenShakeNormal());
   }
}
