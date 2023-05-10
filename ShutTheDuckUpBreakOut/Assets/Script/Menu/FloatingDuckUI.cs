using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FloatingDuckUI : MonoBehaviour
{
  
    public Vector3 ScaleUp;
    public Vector3 RotateTo;
    private Vector3 startScale;
    private Vector3 startRotation;
    public float Timer;

    void Start()
    {
        
        startScale = this.gameObject.transform.localScale;

         this.gameObject.transform.DOScale(ScaleUp,Timer).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutSine);
         this.gameObject.transform.DORotate(RotateTo,Timer).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutSine);

    }

}


