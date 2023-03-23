using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShakeHandler : MonoBehaviour
{
    public float duratoin;
    public bool BeginScreenShake = false;
    public AnimationCurve Anim;
    
   
     void Update()
    {
        if(BeginScreenShake)
        {
            BeginScreenShake = false;
            StartCoroutine(ScreenShake());
        }    
    }

   IEnumerator ScreenShake()
   {
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
}
