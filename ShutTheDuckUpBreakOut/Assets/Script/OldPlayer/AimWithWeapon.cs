using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWithWeapon : MonoBehaviour
{   
    private Camera maincam;
    private Vector3 mousepos;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        maincam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        mousepos = maincam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousepos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);
    }
}
