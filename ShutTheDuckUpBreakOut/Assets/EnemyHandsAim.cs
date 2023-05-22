using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandsAim : MonoBehaviour
{
     // Start is called before the first frame update
    private UnityEngine.Vector3 player;
    private Camera cam;
    private Rigidbody2D rb;
    public GameObject Enemy;
    public GameObject playerpos;
    void Start()
    {
        playerpos = GameObject.FindGameObjectWithTag("Player"); 
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
       

        float Zrotation = transform.rotation.eulerAngles.z;
        if(Zrotation >=90 && Zrotation <= 270)
        {
            Enemy.GetComponent<SpriteRenderer>().flipX = true; 
            gameObject.transform.localScale =  new UnityEngine.Vector3(1,-1,1); 
        }
        else
        {
            Enemy.GetComponent<SpriteRenderer>().flipX = false; 
            gameObject.transform.localScale =  new UnityEngine.Vector3(1,1,1); 
        } 
        player = playerpos.gameObject.transform.position;
        UnityEngine.Vector3 aimdirection = player - transform.position;
        float angel = Mathf.Atan2(-aimdirection.y, -aimdirection.x) * Mathf.Rad2Deg;
        transform.rotation =   UnityEngine.Quaternion.Euler(0,0,angel);         
    }    
}
