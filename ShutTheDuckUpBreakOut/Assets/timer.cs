using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    public float timeramaning = 0;
    public TMP_Text TimeText;
    public Player PlayerHeat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(PlayerHeat.Heat == true)
        {
            if(timeramaning >= 0){
                timeramaning += Time.deltaTime; 
                DisplayTime(timeramaning);
            }
        }
        else{return;}
    }


    void DisplayTime (float timetodesplay){
        timetodesplay += 1;
        float minuts = Mathf.FloorToInt (timetodesplay / 60);
        float seconds = Mathf.FloorToInt (timetodesplay % 60);
        TimeText.text = string.Format("{0:00} : {1:00}",minuts , seconds);
    }
}
