using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int  maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    

    void Death()
    {
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Bullet")
        {
            collider.GetComponent<Health>().currentHealth--;
            Debug.Log("Hit");
        }
}
}
