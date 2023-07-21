using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarFinish : MonoBehaviour
{
    public GameObject Player;
    public GameObject Key;
    public GameObject Fadeout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Vector2.Distance(transform.position,Player.transform.position) < 3 )
         {
            Key.SetActive(true);
            if(Input.GetKey(KeyCode.E))
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
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);


    }
}
