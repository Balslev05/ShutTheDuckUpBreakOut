using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossHealingPot : MonoBehaviour
{
    public void Up()
    {
        transform.DOMoveY(transform.position.y + 3 , 2);
        
        transform.DOLocalRotate(new Vector3(0, 0, 1260), 2, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.OutBack);    
    }
    public void Down()
    {
       transform.DOMoveY(transform.position.y + -3.5f ,0.2f).SetEase(Ease.OutCubic);
       Destroy(this.gameObject,0.2f);
    }
    
    
    
}
