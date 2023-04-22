using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DangeSignPopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(3,3,3),0.3f).SetEase(Ease.OutBack);



        
        StartCoroutine(HidePopUP());
    }

    IEnumerator HidePopUP()
    {
        yield return new WaitForSeconds(1);
        transform.DOScale(new Vector3(0,0,0),0.5f).SetEase(Ease.InCubic);

    }
}
