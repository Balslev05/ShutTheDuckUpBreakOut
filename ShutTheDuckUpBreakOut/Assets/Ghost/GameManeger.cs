using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    // Start is called before the first frame updat
    public GameObject PrisonDust;
    public GameObject PrisonAmbiant;
    public bool Outdoor = false;
    public GameObject CamConstrains;
    public bool Free = true;
   
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && Outdoor == false)
        {
        PrisonDust.SetActive(false);
        Outdoor = true;
        Free = true;
        CamConstrains.SetActive(false);
        PrisonAmbiant.SetActive(false);
        }
        if(collider.gameObject.tag == "Player" && Outdoor == true)
        {
        PrisonAmbiant.SetActive(true);
        PrisonDust.SetActive(true);
        }
        
    }
}
