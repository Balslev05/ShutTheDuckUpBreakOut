using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 
public class JokerBaground : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 RotateTo;
    public Vector3 ScaleUp;

    public float Timer;

    void Start()
    {
         this.gameObject.transform.DORotate(RotateTo,Timer).SetLoops(-1,LoopType.Yoyo);
         this.gameObject.transform.DOScale(ScaleUp,Timer).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutSine);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
