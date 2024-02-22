using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerGhost : MonoBehaviour
{
    public float ghostdelay;
    public float GhostLifeTime;
    public bool GhostReady;
    public GameObject prefab_ghost;
    public BulletTime mechanics;
    public GameObject GhostParticals;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {

         if(mechanics.timeSlowActiv == true && GhostReady == true)
         {
            GhostReady = false;
            StartCoroutine(ghostSpawn());
        }
    }
        IEnumerator ghostSpawn()
        {
            GameObject currentGhost = Instantiate(prefab_ghost,transform.position,transform.rotation);
            Sprite currensprite = GetComponent<SpriteRenderer>().sprite;
            currentGhost.GetComponent<SpriteRenderer>().sprite = currensprite;
            
            if(this.gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                currentGhost.GetComponent<SpriteRenderer>().flipX = true;
            } 
            else{    
                currentGhost.GetComponent<SpriteRenderer>().flipX = false;
            }
            currentGhost.GetComponent<SpriteRenderer>().DOColor(Color.green,0.5f);



            yield return new WaitForSeconds(ghostdelay);
            GhostReady = true;

            Destroy(currentGhost,GhostLifeTime);
            yield return new WaitForSeconds(GhostLifeTime - 0.1f);
            Instantiate(GhostParticals,currentGhost.transform.position,transform.rotation);
            print("SpawnedGhost");
        }
}

