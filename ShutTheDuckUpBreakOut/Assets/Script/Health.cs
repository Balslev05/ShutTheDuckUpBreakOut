using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int  maxhealth;
    public float currentHealth;


    void Start()
    {
        currentHealth = maxhealth;
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
