using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarFinish : MonoBehaviour
{
    public GameObject Player;
    public GameObject Key;
    public GameObject Fadeout;
    public timer ScoreTimer;
    
    public float lastTime;
    public FinalWaves finalwavesScript;

    // Start is called before the first frame update
    void Start()
    {
       Debug.Log(lastTime);
    }

    // Update is called once per frame
    void Update()
    {
         if(Vector2.Distance(transform.position,Player.transform.position) < 3 )
         {
            Key.SetActive(true);
            if(Input.GetKey(KeyCode.E) && finalwavesScript.TimerCounting == true)
            {
                StartCoroutine(FinishGame());
            }
         }
         if(Vector2.Distance(transform.position,Player.transform.position) > 3 )
         {
            Key.SetActive(false);
         }
         
    }
    IEnumerator FinishGame()
    {
        Fadeout.SetActive(false);
        SetTimerScorer();
        yield return new WaitForSeconds(0.01f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void SetTimerScorer(){
        Finish.TotalScorer = ScoreTimer.timeramaning;
    }
}
