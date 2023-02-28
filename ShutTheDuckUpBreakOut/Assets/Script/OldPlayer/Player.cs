using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private AimWithWeapon weapon;
    // Start is called before the first frame update

    void Awake()
    {
    weapon = GetComponentInChildren<AimWithWeapon>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   }
