using System.Net.Mime;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ContinueUI : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler{
    // Start is called before the first frame update
    public Vector3 ContineueTextZoomOut;
    [SerializeField] private Vector3 ContineueSize;
    public float timer;
    public TMP_Text Text_Continue;
    public string Text;
    public float SwitchSceneTimer;
    private string currentText;
    public Color TextColor;
    public bool Ready;
    void Start()
    {
        ContineueSize = this.gameObject.transform.localScale;
        StartCoroutine(TypinContinue());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Ready == true)
        {
        Text_Continue.color = Color.green;
        this.gameObject.transform.DOScale(ContineueTextZoomOut,1f).SetEase(Ease.OutQuint);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(Ready == true){
        Text_Continue.color = TextColor;
        this.gameObject.transform.DOScale(ContineueSize,1f).SetEase(Ease.OutQuint);
        }
    }


    IEnumerator TypinContinue() 
    { 
        yield return new WaitForSeconds(2);
        for (int i = 0; i < Text.Length + 1; i++)
        {
            currentText = Text.Substring(0,i);
            Text_Continue.text = Text_Continue.text + "|";
            yield return new WaitForSeconds(timer);
            Text_Continue.text = currentText.ToString();
            yield return new WaitForSeconds(timer);
        } 
        Text_Continue.color = TextColor;
        Ready = true;        
    }
   public void OnClick()
   {
    print("Clickt");
    Text_Continue.color = Color.white;
    Ready = false;
    Text_Continue.DOFade(0,SwitchSceneTimer).SetEase(Ease.OutCirc);
    StartCoroutine(switchSceneDelay());
   }
   IEnumerator switchSceneDelay()
   {
    yield return new WaitForSeconds(SwitchSceneTimer + 1);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

   }

}

       /*  the old way -.-
        Text_Continue.text = "";
        yield return new WaitForSeconds(timer+2);
        Text_Continue.text = ".";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "c";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "c.";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "co";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "co.";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "con";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "con.";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "cont";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "cont.";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "conti";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "conti.";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "contin";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "contin.";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "continu";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "continu.";
        yield return new WaitForSeconds(timer);
        Text_Continue.text = "continue";
        Ready = true; */