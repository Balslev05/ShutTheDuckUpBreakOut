using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
  public Weapon Weapon;
  public Guns Gun;
  public bool CarryingMelee = false;
  public bool CarryingGun = false;


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
      
      if(collider.gameObject.tag == "Melee")
      {
      
        if(Input.GetKey(KeyCode.E)  && CarryingMelee == false && CarryingGun == false)
        {
          CarryingMelee = true;
          
          Weapon.CurrentWeapon = collider.GetComponent<Item_Melee>().MeleeType;


          Destroy(collider.gameObject);

          Weapon.PickUpWeapon();

        }
    
      }
      if(collider.gameObject.tag == "Gun")
      {
      
        if(Input.GetKey(KeyCode.E)  && CarryingGun == false && CarryingMelee == false)
        {
          
          CarryingGun = true;

          Gun.CurrentGun = collider.GetComponent<Item_Gun>().GunType;
          

          Destroy(collider.gameObject);
          Gun.PickUpWeapon();
        }
      }
    }
}