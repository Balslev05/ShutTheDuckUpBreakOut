using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator WeaponAnim;
    public bool ReadyToAttack;
    public float AttackCooldown;

    public Transform circleOrigin;
    public float Radius;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && ReadyToAttack)
        {
            ReadyToAttack = false;

            WeaponAnim.Play("WeaponAttackAnimation");
        
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {

        yield return new WaitForSeconds (AttackCooldown);

        ReadyToAttack = true;
    }

}
