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
        StartCoroutine(SpawnEnemy());
    }

     IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < NumberOfEnemy; i++)
        {
            Instantiate(Enemy,transform.position,Quaternion.identity);
            yield return new WaitForSeconds(Timebetween);
        }
    }


}
