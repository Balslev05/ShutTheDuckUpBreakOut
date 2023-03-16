using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public Transform ShootPoint;
    public GameObject BulletPrefab;
    public Objects_Guns CurrentGun;
    public GameObject ItemDrop;
    public Player playerStats;
    public Animator GunAnim;
    public bool ReadyToShoot;
    [Header ("Throw")]
    public float ChargeTimer;
    public float Time_Charge;

    //Stats Based on Scriptebal Object
    [Header ("Stats")]
    public int SpeedBullet; // how fast bullet goes
    public float BulletSpread;
    [SerializeField] private int BulletDamage; // damage that you do
    [SerializeField] private int ShotsInMagasin; // how many times it can shoots
    [SerializeField] private int RealodeSpeed; // how fast you realode
    [SerializeField] private int TimebetweenShots; // the damage you do
    [SerializeField] private int BulletFiredPerShot; // how many bullets that are Shots  
    [SerializeField] private int Gunweight; // Slows the Cooldown
    [SerializeField] private int KnockBack; //knockbacks the enemy
    [SerializeField] private Sprite GunSprite; // gun sprite
    
    void Awake()
    {
        KnockBack *= -1;

    }

    void Update()
    {
        
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

    
    public void OnTriggerEnter2D(Collider2D collider)

    {
        if(collider.gameObject.tag == "Enemy")
        {
            collider.GetComponent<Health>().currentHealth -= BulletDamage;

            Vector3 dirFromAttack = - (collider.transform.position - transform.position).normalized;

            collider.transform.position += dirFromAttack * KnockBack;
            

            ShotsInMagasin --;
            
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

        ReadyToShoot = false;
        
        StartCoroutine(AttackCooldown());
    }
 
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(TimebetweenShots + Gunweight / 4);
        ReadyToShoot = true;
    }
    public void DestroyWeapon()
    {
        resetsweapon();
    }
    public void PickUpWeapon()
    {      
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
        
       
    }



}
