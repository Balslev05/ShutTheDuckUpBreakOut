using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Egg : MonoBehaviour
{
    private screenShakeHandler screenshake;
    public ParticleSystem EggSlices;
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
        screenshake.StartScreenShake();
    }
    public void EggExploade()
    {
        Instantiate(EggSlices,this.transform.position,Quaternion.identity);
    }
}
