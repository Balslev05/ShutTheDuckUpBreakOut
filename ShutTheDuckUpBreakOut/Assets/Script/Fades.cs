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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInAndOut());
    }
    public IEnumerator FadeInAndOut()
    {
        yield return new WaitForSeconds(StartWaitingTime);
        ObjectToFade.DOFade(0,FadeOutTimer).SetEase(Ease.InOutSine);
        
    }
}

