using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Fades : MonoBehaviour
{
    
    public Image ObjectToFade;
    public float StartWaitingTime;
    public float FadeOutTimer;
    public bool InOut;
    // Start is called before the first frame update
    void Start()
    {
        if(InOut == true)
        {
        StartCoroutine(FadeInAndOut());
        } else{StartCoroutine(FadeOutAndIn());}


    }
    public IEnumerator FadeInAndOut()
    {
        yield return new WaitForSeconds(StartWaitingTime);
        ObjectToFade.DOFade(0,FadeOutTimer).SetEase(Ease.InOutSine);
        
    }
     public IEnumerator FadeOutAndIn()
    {
        yield return new WaitForSeconds(StartWaitingTime);
        ObjectToFade.DOFade(10,FadeOutTimer).SetEase(Ease.InOutSine);
        
    }
}

