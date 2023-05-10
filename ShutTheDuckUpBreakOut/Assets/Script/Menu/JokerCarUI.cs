using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class JokerCarUI : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    void Start()
    {
        transform.DOMoveY(transform.position.y + 0.1f , timer).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutSine);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
