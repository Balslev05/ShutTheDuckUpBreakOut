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
    public float Attack_Cooldown;
    public Transform circleOrigin;
    public int throwForce;
    public bool ReadyToAttack;

    //Stats Based on Scriptebal Object
    [Header ("Stats")]
    [SerializeField] private int Damage;  // the damage you do
    [SerializeField] private int Durability; // how many hits you can hit 
    [SerializeField] private int weight; // Slows the Cooldown
    [SerializeField] private int KnockBack; //knockbacks the enemy
    [SerializeField] private Sprite WeaponSprite; //knockbacks the enemy
    
    void Awake()
    {
        KnockBack *= -1;

    }

    void Update()
    {
        //throw
        if(Input.GetKeyDown(KeyCode.Space) && playerStats.CarryingWeapon == true)
        {
            ThrowWeapon();
        }
        //destroy the weapon
        if(Durability <= 0 && playerStats.CarryingWeapon == true)
        {
            DestroyWeapon();
        }
        //Attack
        if(Input.GetKeyDown(KeyCode.Mouse0) && ReadyToAttack && playerStats.CarryingWeapon == true)
        {
            Attack();
        }
    }

    
    public void OnTriggerEnter2D(Collider2D collider)

    {
        if(collider.gameObject.tag == "Enemy")
        {
            collider.GetComponent<Health>().currentHealth -= Damage;

            Vector3 dirFromAttack = - (collider.transform.position - transform.position).normalized;

            collider.transform.position += dirFromAttack * KnockBack;

           print("wow");
            Durability --;
            
        }           
    }
  
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(Attack_Cooldown + weight / 4);
        ReadyToAttack = true;
    }
    
    void Attack()
    {
        ReadyToAttack = false;

        WeaponAnim.Play("WeaponAttackAnimation");

        StartCoroutine(AttackCooldown());
    }

    public void DestroyWeapon()
    {
        resetsweapon();
    }

    public void PickUpWeapon()
    {    
        Damage = CurrentWeapon.Damage;
        KnockBack = CurrentWeapon.KnockBack;
        Durability = CurrentWeapon.Durability;
        weight = CurrentWeapon.weight;
        
        SpriteRenderer ItemSprite = this.gameObject.GetComponent<SpriteRenderer>();
        ItemSprite.sprite = CurrentWeapon.sprite;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void ThrowWeapon()
    {
        playerStats.CarryingWeapon = false;
        resetsweapon();
        GameObject thrownWeapon = Instantiate(ItemDrop, transform.position, transform.rotation); 
        thrownWeapon.GetComponent<Item>().weaponType = CurrentWeapon;
        //thrownWeapon.AddComponent<>
        //Throw your current Weapon
    }
    public void resetsweapon()
    {
        Damage = 0;
        KnockBack = 0;
        Durability = 0;
        weight = 0;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

       
    }
}

