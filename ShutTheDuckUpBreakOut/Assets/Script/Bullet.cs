using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousepos;
    private  Camera MainCamera;
    public float force;  
    public Guns BulletStats;
    public Rigidbody2D rb;
    public float BulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        BulletStats = GameObject.FindGameObjectWithTag("PlayerGunStats").GetComponent<Guns>();
        BulletDamage = BulletStats.BulletDamage;

        rb = GetComponent<Rigidbody2D>();
    /*
        mousepos = MainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousepos -transform.position;
        Vector3 rotation = transform.position - mousepos;

       
        
        rb.velocity = new Vector2(direction.x, direction.y).normalized * BulletStats.SpeedBullet + new Vector2(Spreadangle,Spreadangle);
        */
        float Spreadangle = Random.Range(-BulletStats.BulletSpread, BulletStats.BulletSpread);

        rb.velocity = (transform.right+transform.up * Spreadangle).normalized * BulletStats.SpeedBullet;

        Destroy(gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" )
        {
            // do nothing
        } 
        else
        {
        Destroy(this.gameObject);  
        }
    }
   
}
