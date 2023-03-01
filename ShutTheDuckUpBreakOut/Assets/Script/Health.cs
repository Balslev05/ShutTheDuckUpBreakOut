using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth, maxhealth;


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
