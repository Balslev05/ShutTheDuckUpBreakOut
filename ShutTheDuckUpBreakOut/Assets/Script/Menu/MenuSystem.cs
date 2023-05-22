using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class MenuSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool MenuOpen = false;
    public bool MenuSwitch;
    public float Cooldown;
    [Header("UI")]
    public Image Background;
    public TMP_Text Continue;
    public TMP_Text Levels;
    public TMP_Text Quit;
    public Image Titel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&& MenuOpen == true &&  MenuSwitch == true)
        {
              StartCoroutine(UIGoindAway());
        } 
        if(Input.GetKeyDown(KeyCode.Escape) && MenuOpen == false && MenuSwitch == true)
        {
          StartCoroutine(OpenMenu());
        }
    }
    IEnumerator OpenMenu()
    {
        Background.rectTransform.DOAnchorPosY(0,Cooldown/2).SetEase(Ease.OutExpo);
            
        print("OpenMenu");
        MenuOpen = true;
        MenuSwitch = false;
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.01f;

        yield return new WaitForSeconds(Cooldown);
         StartCoroutine(UIPoppingUp());
        StartCoroutine(WaitTimeBetweenOpenAndClose());
    }
     IEnumerator WaitTimeBetweenOpenAndClose()
    {
        yield return new WaitForSeconds(Cooldown);
        MenuSwitch = true;
       
    }
    IEnumerator UIPoppingUp()
    {
        Continue.enabled = true;
        Continue.rectTransform.DOScale(new Vector3(1,1,1),0.25f);
        yield return new WaitForSeconds(0.25f/2);
        
        Levels.enabled = true;
        Levels.rectTransform.DOScale(new Vector3(1,1,1),0.25f);
        yield return new WaitForSeconds(0.25f/2);

        Quit.enabled = true;
        Quit.rectTransform.DOScale(new Vector3(1,1,1),0.25f);
        yield return new WaitForSeconds(0.25f);

        Titel.rectTransform.DOScale(new Vector3(10,5.5f,0),0.25f);


    }
     IEnumerator UIGoindAway()
    {
        Continue.rectTransform.DOScale(new Vector3(0,0,0),0.25f);
        Levels.rectTransform.DOScale(new Vector3(0,0,0),0.25f);
        Quit.rectTransform.DOScale(new Vector3(0,0,0),0.25f);
        Titel.rectTransform.DOScale(new Vector3(0,0,0),0.25f);
        yield return new WaitForSeconds(0.25f);

        Background.rectTransform.DOAnchorPosY(1100,Cooldown).SetEase(Ease.OutExpo);
        MenuOpen = false;
        MenuSwitch = false;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;

        StartCoroutine(WaitTimeBetweenOpenAndClose());

        }

    public void Button_Continue()
    {
        Continue.enabled = false;
        Levels.enabled = false;
        Quit.enabled = false;


        Continue.rectTransform.DOScale(new Vector3(0,0,0),0.01f);
        StartCoroutine(UIGoindAway());
        

    }
    public void Button_Levels()
    {
        Continue.enabled = false;
        Levels.enabled = false;
        Quit.enabled = false;

        Levels.GetComponent<UIInteractive>().enabled = false;
        Levels.rectTransform.DOScale(new Vector3(0,0,0),0.01f);
        
    }
    public void Button_Quit()
    {
        Continue.enabled = false;
        Levels.enabled = false;
        Quit.enabled = false;

        Quit.GetComponent<UIInteractive>().enabled = false;
        Quit.rectTransform.DOScale(new Vector3(0,0,0),0.01f);
        Application.Quit();
    }



}
