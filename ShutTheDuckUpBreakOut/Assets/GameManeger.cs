using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    // Start is called before the first frame updat
    public GameObject PrisonDust;
    public GameObject PrisonAmbiant;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "")
        {

        }
    }
}
