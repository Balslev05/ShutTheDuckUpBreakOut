using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWithWeapon : MonoBehaviour
{   
    private Camera maincam;
    private Vector3 mousepos;
    public GameObject player;
    public Collider2D WeaponCollider;
    
    void Start()
    {
        WeaponCollider.enabled = false;

        maincam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
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

        mousepos = maincam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousepos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);
    }
    public void activateAttackCollider()
    {
        WeaponCollider.enabled = true;
    }
    public void DeactivateAttackCollider()
    {
        WeaponCollider.enabled = false;
    }
}
