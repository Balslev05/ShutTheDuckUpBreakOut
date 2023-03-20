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
}
