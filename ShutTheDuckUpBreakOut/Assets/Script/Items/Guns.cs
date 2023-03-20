using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public GameObject ItemDrop;
    public GameObject BulletPrefab;
    public Objects_Guns CurrentGun;
    public Player playerStats;
    public Transform ShootPoint;
    public Animator GunAnim;
    public bool HasAGun;
    public bool ReadyToShoot;
    [Header ("Throw")]
    public float ChargeTimer;
    public float Time_Charge;

    //Stats Based on Scriptebal Object
    [Header ("Stats")]
    public int SpeedBullet; // how fast bullet goes
    public float BulletSpread;
    public float BulletDamage; // damage that you do
    public int ShotsInMagasin; // how many times it can shoots
    public int RealodeSpeed; // how fast you realode
    public int TimebetweenShots; // the damage you do
    public int BulletFiredPerShot; // how many bullets that are Shots  
    public int Gunweight; // Slows the Cooldown
    public int KnockBack; //knockbacks the enemy
    public Sprite GunSprite; // gun sprite

    
    void Awake()
    {
        KnockBack *= -1;

    }

    void Update()
    {
        if(playerStats.CarryingGun == false)
        {
            return;
        }

        //throw
        if(Input.GetKey(KeyCode.Space) && playerStats.CarryingGun == true)
        {
            ChargeTimer += Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Space) && playerStats.CarryingGun == true)
        {
            AttemptToThrow();  
        }
        //destroy the weapon
        if(ShotsInMagasin <= 0 && playerStats.CarryingGun == true)
        {
            DestroyWeapon();
        }
        //Attack
        if(Input.GetKeyDown(KeyCode.Mouse0) && ReadyToShoot == true && playerStats.CarryingGun == true)
        {
            
            Shoot();
        }
    }

    void Shoot()
    {
        
        ReadyToShoot = false;

        if(Gunweight >= 3){
            //play anim HeavyAnim
            GunAnim.Play("GunFireHeavy");
        }
        if(Gunweight <= 2){
            //play anim LightAnim
            GunAnim.Play("GunFire");
        }
        for (int i = 0; i < BulletFiredPerShot; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab, ShootPoint.position, transform.parent.rotation);
        }

        ShotsInMagasin --;

        ReadyToShoot = false;
        
        StartCoroutine(AttackCooldown());
    }
 
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(TimebetweenShots + Gunweight / 4);
        ReadyToShoot = true;
    }
    public void PickUpWeapon()
    {      
        playerStats.CarryingGun = true;
        ReadyToShoot = true;

        BulletDamage = CurrentGun.BulletDamage;
        RealodeSpeed = CurrentGun.RealoadeSpeed;
        SpeedBullet = CurrentGun.SpeedBullet;
        ShotsInMagasin = CurrentGun.ShotsInMagasin;
        BulletFiredPerShot = CurrentGun.bulletFiredPerShot;
        Gunweight = CurrentGun.Weight;
        BulletSpread = CurrentGun.bulletSPread;
        KnockBack = CurrentGun.knockBack;

        SpriteRenderer ItemSprite = this.gameObject.GetComponent<SpriteRenderer>();
        ItemSprite.sprite = CurrentGun.sprite;

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
        playerStats.CarryingGun = false;
        resetsweapon();
        GameObject thrownWeapon = Instantiate(ItemDrop, transform.position, transform.rotation); 
        thrownWeapon.GetComponent<Item_Gun>().GunType = CurrentGun;

        thrownWeapon.GetComponent<Item_Gun>().IsItThrown = true;

        //thrownWeapon.AddComponent<>
        //Throw your current Weapon
    }
    public void resetsweapon()
    {
        BulletDamage = 0;
        KnockBack = 0;
        ShotsInMagasin = 0;
        ShotsInMagasin = 0;
        Gunweight = 0;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        playerStats.CarryingGun = false;

        
       
    }

    public void DestroyWeapon()
    {
        resetsweapon();
    }


}
