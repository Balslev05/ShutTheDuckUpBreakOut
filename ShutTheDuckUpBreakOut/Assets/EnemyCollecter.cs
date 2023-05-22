using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollecter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Enemies;
    [Header("Doors")]
    public Door Outdoor;
    public Door office;
    public Door Out;
    public Door door1;
    public Door door2;
    public Door door3;
    public Door door4;
    public Door door5;

    [Header("Spawners")]
    public GameObject EnemySpawner1;
    public GameObject EnemySpawner2;
    public GameObject EnemySpawner3;
    public GameObject EnemySpawner4;
    public GameObject EnemySpawner5;
    public GameObject EnemySpawner6;
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
            Outdoor.Open = true;
            office.Open = true;
            Out.Open = true;
            
            door1.Open = true;
            door2.Open = true;
            door3.Open = true;
            door4.Open = true;
            door5.Open = true;




            EnemySpawner1.SetActive(true);
            EnemySpawner2.SetActive(true);
            EnemySpawner3.SetActive(true);
            EnemySpawner4.SetActive(true);
            EnemySpawner5.SetActive(true);
            EnemySpawner6.SetActive(true);
        }
    }
}
