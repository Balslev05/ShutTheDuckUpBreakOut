using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalWaves : MonoBehaviour
{
    public GameObject[] Spawners;
    public float timer = 5;
   public bool WaveOnGoing;
   public bool TimerCounting;
    public TMP_Text StatusText;
    [SerializeField] GameObject[] Enemies;
    
    void Start()
    {
        StartCoroutine(StartRounds());
     
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(Enemies.Length > 0)
        {
            WaveOnGoing = true;
        }

        if(Enemies.Length == 0 && WaveOnGoing == true)
        {
            StartCoroutine(EnemyTimer());
        }
        if(WaveOnGoing == true)
        {
        StatusText.text = ("Deafeat the Remaining Enemies to leave:"+ Enemies.Length);


        } if (WaveOnGoing == false && TimerCounting == false) {

            StartCoroutine(TimeToEscape());
            print("wavenotgoing");

        }
    }

      IEnumerator EnemyTimer()
    {
        yield return new WaitForSeconds(2);
        WaveOnGoing = false;
    }

    IEnumerator  StartRounds()
    {
        for (int i = 0; i < Spawners.Length; i++)
            {
                StopCoroutine(TimeToEscape());

                Spawners[i].SetActive(true);
                Spawners[i].GetComponent<EnemySpawner>().EnemyStarter();
                StatusText.enabled = true;
            }
                yield return new WaitForSeconds(1f);
    }
      IEnumerator TimeToEscape()
    {
        
        print("StartTier");

        timer = 9;
        for (int i = 0; i < 9; i++)
        {
            if(Enemies.Length > 0 ){
                break;
                }
            StatusText.text = ("Leave before renforces {00:0"+ timer +"}");
            TimerCounting = true;
        yield return new WaitForSeconds(1);
            timer -= 1;
            
        }
        print("finishTimer");

        StartCoroutine(StartRounds());
        WaveOnGoing = true; 
        TimerCounting = false;
    }   
}
