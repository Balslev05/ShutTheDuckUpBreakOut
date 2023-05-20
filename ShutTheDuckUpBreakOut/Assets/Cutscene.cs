using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchScene());
    }

  IEnumerator SwitchScene()
  {

    yield return new WaitForSeconds(timer);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
  }
}
