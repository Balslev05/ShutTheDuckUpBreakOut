using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bullet : MonoBehaviour
{
    private Vector3 mousepos;
    private  Camera MainCamera;
    public float force;  
    public Guns BulletStats;
    public Rigidbody2D rb;
    public float BulletDamage;
    public GameObject BulletDust;
    
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        BulletStats = GameObject.FindGameObjectWithTag("PlayerGunStats").GetComponent<Guns>();
        
        BulletDamage = BulletStats.BulletDamage;



        rb = GetComponent<Rigidbody2D>();
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
          if(collider.gameObject.tag == "Enemy")
          {
            Vector3 dirFromAttack = - (collider.transform.position - transform.position).normalized;
                
            Vector3 knockback;
            knockback = collider.transform.position += dirFromAttack * -BulletStats.KnockBack;
            collider.transform.DOMove( new Vector3 (knockback.x,knockback.y,knockback.z),0.3f).SetEase(Ease.OutCirc);
          }
        

        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Bullet" || collider.gameObject.tag =="Gun" || collider.gameObject.tag == "Melee"){
            // do nothing

        }
         
        else
        {
            GameObject Dust = Instantiate(BulletDust,this.transform.position,Quaternion.identity);
            Destroy(Dust,1f);
            Destroy(this.gameObject);  
        }
    }


   
}
