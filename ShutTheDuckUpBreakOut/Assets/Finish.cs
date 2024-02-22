using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Finish : MonoBehaviour
{
    	public static float TotalScorer;
        public  float BestTime;

        public TMP_Text YourTime;
        public TMP_Text PointText;
        public TMP_Text NewBest;
        
        public GameObject varation1; 
        public GameObject varation2; 
        public GameObject varation3; 
        
        public void Start()
        {


            if(BestTime <= 1){
                BestTime = TotalScorer;
                PlayerPrefs.SetFloat("BestTime",BestTime);
            }

            NewBest.enabled = false;
            GetScorer();
            DisplayTime(TotalScorer);

 
           
            

            BestTime = PlayerPrefs.GetFloat("BestTime");
            if(BestTime > TotalScorer)
            {
                BestTime = TotalScorer;
                NewBest.enabled = true;
                PlayerPrefs.SetFloat("BestTime",BestTime);
            }
        }
        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                DisplayTime(BestTime);
                YourTime.text =("Your BEST Time");

            } else if(Input.GetKeyUp(KeyCode.Tab))
                {
                    YourTime.text =("Your Time");
                    DisplayTime(TotalScorer);
                }

                if(Input.GetKeyDown(KeyCode.I))
                {
                    varation1.SetActive(true);
                    varation2.SetActive(false);
                    varation3.SetActive(false);

                    YourTime.color = Color.white;
                    PointText.color = Color.white;
                    NewBest.color = Color.white;
                }
                 if(Input.GetKeyDown(KeyCode.O))
                {
                    varation1.SetActive(false);
                    varation2.SetActive(true);
                    varation3.SetActive(false);

                    YourTime.color = Color.black;
                    PointText.color = Color.black;
                    NewBest.color = Color.black;
                }
                 if(Input.GetKeyDown(KeyCode.P))
                {
                    varation1.SetActive(false);
                    varation2.SetActive(false);
                    varation3.SetActive(true);

                    YourTime.color = Color.white;
                    PointText.color = Color.white;
                    NewBest.color = Color.white;
                }


        }
        public void GetScorer()
        {
            PointText.text = (TotalScorer.ToString());
        }
        
       
        void DisplayTime (float timetodesplay)
        {
            timetodesplay += 1;
            float minuts = Mathf.FloorToInt (timetodesplay / 60);
            float seconds = Mathf.FloorToInt (timetodesplay % 60);
            PointText.text = string.Format("{0:00} : {1:00}",minuts , seconds);
        }
}
