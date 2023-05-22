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

    // Start is called before the first frame update
    void Start()
    {
        contineueSize = new Vector3(1,1,1);
        this.gameObject.GetComponent<TMP_Text>().color = TextColor;
    }
     public void OnPointerEnter(PointerEventData eventData)
    {
        this.gameObject.transform.DOScale(HoverOverSize,2f).SetEase(Ease.OutQuint);
        this.gameObject.GetComponent<TMP_Text>().color = HoverOverTextColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.transform.DOScale(contineueSize,2f).SetEase(Ease.OutQuint);
        this.gameObject.GetComponent<TMP_Text>().color = TextColor;        
    }
}
