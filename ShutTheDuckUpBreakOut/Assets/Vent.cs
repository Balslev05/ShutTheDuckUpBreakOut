using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Vent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Key;
    public GameObject EndOfVent;

    [SerializeField] GameObject[] EnemiCollecter;

    public GameObject FinalWaves;

    public GameObject x;
    
    
    void Start()
    {

    }
    void Update()
    {
        EnemiCollecter = GameObject.FindGameObjectsWithTag("Enemy");
        
    }

   void OnCollisionStay2D(Collision2D other)
   {
        
        if(EnemiCollecter.Length == 0){
        Key.SetActive(true);
            x.SetActive(false);

        }
         if(EnemiCollecter.Length > 0){
            x.SetActive(true);
            Key.SetActive(true);
        //! somthing else LIKE A X Key.SetActive(true);
        }



        if(Input.GetKey(KeyCode.E) && EnemiCollecter.Length == 0)
        {
            other.transform.position = EndOfVent.transform.position;
            
            FinalWaves.SetActive(true);
        }
   }
   void OnCollisionExit2D(Collision2D other)
   {
    Key.SetActive(false);
   }
}
