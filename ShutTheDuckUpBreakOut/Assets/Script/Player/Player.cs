using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
  public Health playerHealth;
  public Image HealthUI;
  public Weapon Weapon;
  public Guns Gun;
  public bool CarryingMelee = false;
  public bool CarryingGun = false;
  [Header  ("UI") ]
  public Image GunIcon;
  public TMP_Text MaxInMagasin;
  public TMP_Text CurrentInMagasin;
  public TMP_Text GunName;
  public GameObject GunUI;


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
      HealthUI.fillAmount = playerHealth.currentHealth / 10;

      if(CarryingGun == true)
      {
        UpdateGunUI();
        GunUI.SetActive(true);
      }
      else
      {
        GunUI.SetActive(false);
      }
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
          UpdateGunUI();
        }
      }
       
    }
     void UpdateGunUI()
    {
        MaxInMagasin.text = Gun.MaxShots.ToString();
        CurrentInMagasin.text = Gun.ShotsInMagasin.ToString();
        GunName.text = Gun.GunName.ToString();
        GunIcon.sprite = Gun.GunSprite;
    }
}