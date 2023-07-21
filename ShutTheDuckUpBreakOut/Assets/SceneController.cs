using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class SceneController : MonoBehaviour
{
    public AudioSource PoliceSound;
    public Health boss;
    // Start is called before the first frame update
    void Update()
    {
       if(boss.currentHealth <= 0){
        StartCoroutine(BossIsDead());
       }
    }
    public IEnumerator BossIsDead()
    {
        PoliceSound.DOFade(0.8f,10);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
