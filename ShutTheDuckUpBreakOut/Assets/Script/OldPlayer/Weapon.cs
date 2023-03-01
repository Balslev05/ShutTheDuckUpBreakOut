using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator WeaponAnim;
    public bool ReadyToAttack;
    public float Attack_Cooldown;
    public Transform circleOrigin;
    public float Radius;
    //Stats Based on Scriptebal Object
    [Header ("Stats")]
    [SerializeField] private int Damage;  // the damage you do
    [SerializeField] private int Durability; // how many hits you can hit 
    [SerializeField] private int weight; // Slows the Cooldown


    
    
    void Update()
    {
        if(Durability <= 0)
        {
            DestroyWeapon();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && ReadyToAttack)
        {
            Attack();
        }
    }

    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            collider.GetComponent<Health>().currentHealth -= Damage;

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
        Destroy(this.gameObject);
    }
}
