using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Mime;
using System.Linq.Expressions;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIInteractive : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Vector3 HoverOverSize;
    public Color HoverOverTextColor;
    private Vector3 contineueSize;
    private Color TextColor = Color.white;
    public MenuSystem Menu;
    private Vector3 startZise;


    // Start is called before the first frame update
    void Start()
    {   
        this.gameObject.GetComponent<TMP_Text>().color = TextColor;
    }
    void Update()
    {
        contineueSize = startZise;
    }
     public void OnPointerEnter(PointerEventData eventData)
    {
        startZise = this.gameObject.gameObject.transform.localScale;
        this.gameObject.transform.DOScale(HoverOverSize,2f).SetEase(Ease.OutQuint);
        this.gameObject.GetComponent<TMP_Text>().color = HoverOverTextColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.transform.DOScale(contineueSize,2f).SetEase(Ease.OutQuint);
        this.gameObject.GetComponent<TMP_Text>().color = TextColor;        
    }
}
