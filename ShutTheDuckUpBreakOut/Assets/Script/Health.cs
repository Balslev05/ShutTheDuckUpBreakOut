using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int  maxHealth;
    public float currentHealth;
    public bool YouAreThePlayer; // jeg ved godt det her er en dårlig ide men jeg er UTROLIG TRÆT og burde bare gå i seng men vil gerne lige lave det færidgt ser senere om det var det vær 



    [Header ("Knockback")]
     public float knockbackForce = 5.0f;      // The force of the knockback
    public float knockbackDuration = 0.5f;  // The duration of the knockback effect


    private Rigidbody2D rb2D;              // Reference to the Rigidbody2D component
    private Vector2 knockbackDirection;   // The direction of the knockback
    private float knockbackTimer;        // Timer for the knockback effect

    void Start()
    {
        currentHealth = maxHealth;
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
        if(collider.gameObject.tag == "Bullet")
        {
            currentHealth -= collider.GetComponent<Bullet>().BulletDamage;
            
        }
        if (YouAreThePlayer == true && collider.gameObject.tag == "Boss")
        {

        }
}
    void Death()
    {
        Destroy(this.gameObject);
    }
    
}
