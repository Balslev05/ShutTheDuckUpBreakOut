using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollecter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Enemies;

    public Door Outdoor1;
    public Door[] DoorsOpen;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(Enemies.Length == 0)
        {
            print("Open");
            Outdoor1.Open = true;
        }
    }
}
