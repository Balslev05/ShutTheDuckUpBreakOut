using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWithGun : MonoBehaviour
{
    private UnityEngine.Vector3 mousepos;
    public Camera cam;
    private Rigidbody2D rb;
    public GameObject player;
    void Update()
    {
        float Zrotation = transform.rotation.eulerAngles.z;
        if(Zrotation >=90 && Zrotation <= 270)
        {
            player.GetComponent<SpriteRenderer>().flipX = true; 
            gameObject.transform.localScale =  new UnityEngine.Vector3(1,-1,1); 
        }
        else
        {
            player.GetComponent<SpriteRenderer>().flipX = false; 
            gameObject.transform.localScale =  new UnityEngine.Vector3(1,1,1); 
        } 
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        UnityEngine.Vector3 aimdirection = mousepos - transform.position;
        float angel = Mathf.Atan2(-aimdirection.y, -aimdirection.x) * Mathf.Rad2Deg;
        transform.rotation =   UnityEngine.Quaternion.Euler(0,0,angel);         
    }
}



