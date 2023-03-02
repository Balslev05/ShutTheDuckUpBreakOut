using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
  public Weapon weapon;
  public bool CarryingWeapon = true; 

    // Start is called before the first frame update

    void Awake()
    {
      
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void  OnTriggerStay2D(Collider2D collider)
    {
      
      if(collider.gameObject.tag == "Weapon")
      {
      
        if(Input.GetKey(KeyCode.F)  && CarryingWeapon == false)
        {
          CarryingWeapon = true;
          weapon.CurrentWeapon = collider.GetComponent<Item>().weaponType;
          print("1");
          Destroy(collider.gameObject);
          weapon.PickUpWeapon();

        }
      }
    }
}