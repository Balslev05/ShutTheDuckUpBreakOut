using System.Collections;
using UnityEngine;
using DG.Tweening;
public class StartKeyUI : MonoBehaviour
{
    public float Timer;

    void Start()
    {
        StartCoroutine(Blinking());
    }
     IEnumerator Blinking()
     {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds (Timer);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds (Timer);
        StartCoroutine(Blinking());

     }
     

}
