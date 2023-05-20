using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossHealingPot : MonoBehaviour
{
    public Vector3 SrinkDOwnsize;
    [SerializeField] private GameObject Boss;

    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
    }
    void Update()
    {
		
    }
    public void Up()
    {
        this.gameObject.transform.DOScale(SrinkDOwnsize,1f).SetEase(Ease.OutCubic);

        transform.DOMoveY(transform.position.y + 2.5f , 0.3f);       

        transform.DOLocalRotate(new Vector3(0, 0, 180), 1f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.OutBack);

    }
    
    public void Down()
    {

        transform.DOMoveY(transform.position.y - 1.5f ,0.1f).SetEase(Ease.OutExpo);

        Destroy(this.gameObject,0.1f);
    }
    
    
    
}
