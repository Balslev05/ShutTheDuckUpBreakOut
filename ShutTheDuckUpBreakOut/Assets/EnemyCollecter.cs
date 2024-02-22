using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollecter : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject EnemiManager2;
    public Door[] DoorsOpen;
    public GameObject[] Spawners;
    [SerializeField] GameObject[] Enemies;

    
    
    


    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(Enemies.Length == 0)
        {
            for (int i = 0; i < DoorsOpen.Length; i++)
            {
                DoorsOpen[i].GetComponent<Door>().Open = true;
            }
            for (int i = 0; i < Spawners.Length; i++)
            {
                Spawners[i].SetActive(true);
            }
            StartCoroutine(NewManager());
        }
    }
    IEnumerator NewManager()
    {
        yield return new WaitForSeconds(1f);
        EnemiManager2.SetActive(true);
    }
}
