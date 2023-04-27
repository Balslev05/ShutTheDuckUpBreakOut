
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LocationNames : MonoBehaviour
{
    public string LocationName;
    public TMP_Text LocationText;
    private string currentText;
    public Color TextColor;
    public float TypeTimer;
    public float WaitTimer;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypinContinue());
    }

 IEnumerator TypinContinue() 
    { 
        
        yield return new WaitForSeconds(WaitTimer / 2);
        for (int i = 0; i < LocationName.Length + 1; i++)
        {
            currentText = LocationName.Substring(0,i);
            
            LocationText.text = LocationText.text + "|";

            yield return new WaitForSeconds(TypeTimer);
            
            LocationText.text = currentText.ToString();
            
            yield return new WaitForSeconds(TypeTimer);
        } 
        LocationText.color = TextColor;
        yield return new WaitForSeconds(2);
        LocationText.DOFade(0,WaitTimer).SetEase(Ease.OutCirc);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
