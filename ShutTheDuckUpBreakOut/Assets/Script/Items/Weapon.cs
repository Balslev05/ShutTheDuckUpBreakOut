using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Weapon : MonoBehaviour
{
   
    public Objects_Weapons CurrentWeapon;
    public GameObject ItemDrop;
    public Player playerStats;
    public Animator WeaponAnim;
    public float Radius;    
    public Transform circleOrigin;
    public int throwForce;
    public bool ReadyToAttack;

    public float ChargeTimer;
    public float Time_Charge;

    //Stats Based on Scriptebal Object
    [Header ("Stats")]
   
    public int Damage;  // the damage you do
    public int Durability; // how many hits you can hit 
    public int weight; // Slows the Cooldown
    public float KnockBack; //knockbacks the enemy
    public Sprite WeaponSprite; //knockbacks the enemy
    public Vector3 WeaponSize; 
    public Objects_Weapons.Type AttackType = new Objects_Weapons.Type();  

    void Update()
    {
        if(playerStats.CarryingMelee == false)
        {
            return;
        }

        //throw
        if(Input.GetKey(KeyCode.Mouse1) && playerStats.CarryingMelee == true)
        {
            ChargeTimer += Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Mouse1) && playerStats.CarryingMelee == true)
        {
            AttemptToThrow();  
        }
        //destroy the weapon
        if(Durability <= 0 && playerStats.CarryingMelee == true)
        {
            DestroyWeapon();
        }
        //Attack
        if(Input.GetKeyDown(KeyCode.Mouse0) && ReadyToAttack && playerStats.CarryingMelee == true)
        {
            Attack();
        }
    }

    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            Vector3 dirFromAttack = - (collider.transform.position - transform.position).normalized;
            
            Vector3 knockback;
            knockback = collider.transform.position += dirFromAttack * -KnockBack;
            collider.transform.DOMove( new Vector3 (knockback.x,knockback.y,knockback.z),0.3f).SetEase(Ease.OutCirc);

            Durability --;            
        }           
    }


    void Attack()
    {
        playerStats.Heat = true;
        ReadyToAttack = false;    

        WeaponAnim.Play("Anim" + AttackType);
    }

    
    public void PickUpWeapon()
    {   playerStats.CarryingMelee = true;

        Damage = CurrentWeapon.Damage;
        KnockBack = CurrentWeapon.KnockBack;
        Durability = CurrentWeapon.Durability;
        weight = CurrentWeapon.weight;
        WeaponSize = CurrentWeapon.WeaponSize;
        AttackType = CurrentWeapon.AttackType;
        
        this.gameObject.transform.localScale = WeaponSize;
        WeaponSprite = CurrentWeapon.sprite;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = WeaponSprite;

        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
      public void AttemptToThrow()
    {
      if(ChargeTimer >= Time_Charge){
        ThrowWeapon(); 
    

      } 
      ChargeTimer = 0;     

    }
    
    public void ThrowWeapon()
    {
        playerStats.CarryingMelee = false;
        ResetWeapon();
        GameObject thrownWeapon = Instantiate(ItemDrop, transform.position, transform.rotation); 
        thrownWeapon.GetComponent<Item_Melee>().MeleeType = CurrentWeapon;

        thrownWeapon.GetComponent<Item_Melee>().IsItThrown = true;
        
        //Throw your current Weapon
    }
    
    public void ResetWeapon()
    {
        Damage = 0;
        KnockBack = 0;
        Durability = 0;
        weight = 0;
        GetComponent<SpriteRenderer>().enabled = false;
        playerStats.CarryingMelee = false;
    }
    public void DestroyWeapon()
    {
        ResetWeapon();
    }
}

