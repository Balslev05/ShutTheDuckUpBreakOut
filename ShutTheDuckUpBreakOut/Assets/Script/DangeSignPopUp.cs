using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DangeSignPopUp : MonoBehaviour
{
    public float POPUpTimer = 0.3f;
    public float waitbetweenTween;
    public float POPDownTimer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(3,3,3),POPUpTimer).SetEase(Ease.OutBack);



        
        StartCoroutine(HidePopUP());
    }

    IEnumerator HidePopUP()
    {
        yield return new WaitForSeconds(waitbetweenTween);
        transform.DOScale(new Vector3(0,0,0),POPDownTimer).SetEase(Ease.InCubic);

    }
}
