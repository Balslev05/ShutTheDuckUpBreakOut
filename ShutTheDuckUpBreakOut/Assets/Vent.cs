using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Vent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Key;
    public GameObject EndOfVent;
    public CinemachineConfiner Cam;



    public GameObject EnemySpawner1;
    public GameObject EnemySpawner2;
    public GameObject EnemySpawner3;
    public GameObject EnemySpawner4;
    public GameObject EnemySpawner5;
    public GameObject EnemySpawner6;
    public GameObject EnemySpawner7;
    public GameObject EnemySpawner8;
    
    void Start()
    {

    }
    void Update()
    {
        if(Input.GetKey(KeyCode.U))
        {

        }
    }

   void OnCollisionStay2D(Collision2D other)
   {
        Key.SetActive(true);
        if(Input.GetKey(KeyCode.E))
        {
            other.transform.position = EndOfVent.transform.position;

            EnemySpawner1.SetActive(true);
            EnemySpawner2.SetActive(true);
            EnemySpawner3.SetActive(true);
            EnemySpawner4.SetActive(true);
            EnemySpawner5.SetActive(true);
            EnemySpawner6.SetActive(true);
            EnemySpawner7.SetActive(true);
            EnemySpawner8.SetActive(true);
        }
   }
   void OnCollisionExit2D(Collision2D other)
   {
    Key.SetActive(false);
   }
}
