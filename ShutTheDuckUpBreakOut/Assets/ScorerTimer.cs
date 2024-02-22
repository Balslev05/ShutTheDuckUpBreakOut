using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorerTimer : MonoBehaviour
{
      private string timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetFloat(timer);
        Debug.Log(timer);
    }
}
