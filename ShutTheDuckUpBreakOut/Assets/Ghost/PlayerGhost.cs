using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhost : MonoBehaviour
{
    public float ghostdelay;
    public float ghostdelayseconds;
    public GameObject prefab_ghost;
    public YoungMechanics mechanics;
    // Start is called before the first frame update
    void Start()
    {
        ghostdelayseconds = ghostdelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(ghostdelayseconds>0){
            ghostdelayseconds -= Time.deltaTime;

        } else if(mechanics.ghostSpawn == true) {
            GameObject currentGhost = Instantiate(prefab_ghost,transform.position,transform.rotation);
            Sprite currensprite = GetComponent<SpriteRenderer>().sprite;
            currentGhost.GetComponent<SpriteRenderer>().sprite = currensprite;
            ghostdelayseconds = ghostdelay;
            Destroy(currentGhost,1f);
        }
    }
}
