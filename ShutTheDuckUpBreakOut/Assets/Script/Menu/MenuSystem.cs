using System.Xml;
using System.Resources;
using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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

    [Header("Levels")]
    public Image LevelMenu;
    
    // public Image Begening;

    public bool levelsShow = false;

    void Start()
    {
        
    
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&& MenuOpen == true &&  MenuSwitch == true == levelsShow == false)
        {
              StartCoroutine(UIGoindAway());
        } 
        if(Input.GetKeyDown(KeyCode.Escape) && MenuOpen == false && MenuSwitch == true && levelsShow == false)
        {
          StartCoroutine(OpenMenu());
        }
         if(Input.GetKeyDown(KeyCode.Escape)&& MenuOpen == true && levelsShow == true)
        {
              StartCoroutine(HideLevels());
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

        Levels.GetComponent<UIInteractive>().enabled = true;

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
        Continue.enabled = false;
        Levels.enabled = false;
        Quit.enabled = false;

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
        StartCoroutine(ShowLevels());
        Levels.color = Color.white;

        
        
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

    public IEnumerator ShowLevels()
    {
        
        print("Eyy");


        Continue.rectTransform.DOScale(new Vector3(0,0,0),0.25f);
        
        Levels.rectTransform.DOScale(new Vector3(3,3,3),0.5f);

        Quit.rectTransform.DOScale(new Vector3(0,0,0),0.25f);
        Titel.rectTransform.DOScale(new Vector3(0,0,0),0.25f);

        yield return new WaitForSeconds(0.25f);
        print("Eyy");
        LevelMenu.rectTransform.DOAnchorPosX(110,Cooldown/2).SetEase(Ease.OutExpo);
        Background.rectTransform.DOAnchorPosY(-1810,Cooldown).SetEase(Ease.OutExpo);

        levelsShow = true;

    }
     public IEnumerator HideLevels()
    {
          

        Continue.rectTransform.DOScale(new Vector3(0,0,0),0.25f);
        
        Levels.rectTransform.DOScale(new Vector3(3,3,3),0.5f);

        Quit.rectTransform.DOScale(new Vector3(0,0,0),0.25f);
        Titel.rectTransform.DOScale(new Vector3(0,0,0),0.25f);

        yield return new WaitForSeconds(0.25f);

        LevelMenu.rectTransform.DOAnchorPosX(-1810,Cooldown/2).SetEase(Ease.OutExpo);
        Background.rectTransform.DOAnchorPosY(0,Cooldown/2).SetEase(Ease.OutExpo);
        
        StartCoroutine(OpenMenu());
        levelsShow = false;
    }

    // Button LEvels

    public void Begening_Scene()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        if(levelsShow == true){
        SceneManager.LoadScene("StartScreen");
        }   else return ;
    }
     public void Menu_Scene()
     {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        if(levelsShow == true){
        SceneManager.LoadScene("TitelScreen");
        }   else return ;
        
    } 
    public void Cail_Scene()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        if(levelsShow == true){
        SceneManager.LoadScene("Cafeteria");
        }   else return ;
        
    }
    public void Boss_Scene()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        if(levelsShow == true){
        SceneManager.LoadScene("MAP BossFight");
        }   else return ;
    }

}
