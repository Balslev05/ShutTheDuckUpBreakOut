using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public int  maxHealth;
    public float currentHealth; 
    
    
    [Header("PlayerDamage")]
    public screenShakeHandler screenShake;
    public bool CanTakeDamage;
    public Image DamgedOutline;
    public Color playerdamged;
    public float ImortalTimer;
    public bool IsPlayer;




    [Header ("Knockback")]
     public float knockbackForce = 5.0f;      // The force of the knockback
    public float knockbackDuration = 0.5f;  // The duration of the knockback effect


    private Rigidbody2D rb2D;              // Reference to the Rigidbody2D component
    private Vector2 knockbackDirection;   // The direction of the knockback
    private float knockbackTimer;        // Timer for the knockback effect

    void Start()
    {
        currentHealth = maxHealth;
        
        CanTakeDamage = true; 

    }
    void Update()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if(currentHealth <= 0)
        {
            Death();
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == ("Bullet") && IsPlayer == false)
        {
        currentHealth -= collider.GetComponent<Bullet>().BulletDamage;
        }
        if(collider.gameObject.tag == ("MeleeCollider") && IsPlayer == false)
        {
        currentHealth -= collider.GetComponent<Weapon>().Damage; 
        }
        if(collider.gameObject.tag == ("EnemyBluntAttack") && IsPlayer == true)
        {
            PlayerTakeDamage(1); 
            print("AW");
        }

}
    void Death()
    {
        if(gameObject.CompareTag("Boss")) 
        {
            // do nothing 
        } 
        else{Destroy(this.gameObject);}
    }
    public void PlayerTakeDamage(float Damage)
    {
        if(CanTakeDamage == true)
        {
        CanTakeDamage = false;
        currentHealth -= Damage;
        screenShake.StartShake(0.25f,5,2);
        StartCoroutine(VirgentetColorChange());
        }else{return;}


          
    }
    IEnumerator VirgentetColorChange()
    {
        Color NormalCOlor = DamgedOutline.color;
        DamgedOutline.DOColor(playerdamged,ImortalTimer / 5).SetEase(Ease.OutExpo);
        
        yield return new WaitForSeconds(ImortalTimer/5);   
        
        DamgedOutline.DOColor(NormalCOlor,ImortalTimer / 5).SetEase(Ease.InSine);

        yield return new WaitForSeconds(ImortalTimer/2);   
        
        CanTakeDamage = true; 
    }
}
