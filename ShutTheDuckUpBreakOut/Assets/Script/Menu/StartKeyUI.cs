using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class StartKeyUI : MonoBehaviour
{
    public float Timer;
    public GameObject startSound;
    public GameObject fade;
    public AudioSource SceneSound;

    void Start()
    {
        SceneSound.DOFade(0.65f,5);

        StartCoroutine(Blinking());
    }
    void Update()
    {
        if(Input.anyKeyDown)
        {
            StartCoroutine(StartGame());
        }
    }


    IEnumerator StartGame()
    {
        Instantiate(startSound,transform.position,Quaternion.identity);

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        SceneSound.DOFade(0,1);
        fade.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Blinking()
     {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds (Timer);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds (Timer);
        StartCoroutine(Blinking());

     }
     

}
