using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Boss_Egg : MonoBehaviour
{
    private screenShakeHandler screenshake;
    public ParticleSystem EggSlices;
    public GameObject Enemies;
    public int SpawningEnemies;
    // Start is called before the first frame update
    void Start()
    {
        screenshake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<screenShakeHandler>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EggScreenShake()
    {
       screenshake.StartShake(0.1f,5,10);
    }
    public void EggExploade()
    {
        
        
        Instantiate(EggSlices,this.transform.position,Quaternion.identity);
        StartCoroutine(spawnenemies());        
    }
    IEnumerator spawnenemies()
    {
        for (int i = 0; i < SpawningEnemies; i++)
        {
        GameObject PrefabEnemies = Instantiate(Enemies,this.transform.position,Quaternion.identity);

        yield return new WaitForSeconds(0.1f);
        }
    }
}