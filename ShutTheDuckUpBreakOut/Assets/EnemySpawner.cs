using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public int NumberOfEnemy;
    public float Timebetween;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnEnemy());
         StartCoroutine(SpawnEnemy());
    }


    public void EnemyStarter()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        print("Brinrser");
        for (int i = 0; i < NumberOfEnemy; i++)
        {
            yield return new WaitForSeconds(Timebetween);
            Instantiate(Enemy,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(Timebetween);
        }
    }


}
