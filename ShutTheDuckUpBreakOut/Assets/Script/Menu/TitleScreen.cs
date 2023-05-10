using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 ScaleUp;
    private Vector3 StartScale;
    public float Timer;

    void Start()
    {
        
        StartScale = this.gameObject.transform.localScale;

        this.gameObject.transform.DOScale(ScaleUp,Timer).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutSine);

        
       
    }
}
