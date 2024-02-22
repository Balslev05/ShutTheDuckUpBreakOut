using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public float Damage;
    [SerializeField] Vector3 direction;
    public GameObject BulletDust;
    public TrailRenderer Bullettrail;
    bool defelcted;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y , -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Gun") ||  other.gameObject.CompareTag("Melee"))
        {
            print("Hit somthing we should go throug");
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Health>().PlayerTakeDamage(1);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("MeleeCollider"))
        {
            defelcted = true;
            GetComponent<SpriteRenderer>().DOColor(Color.red,0.5f);
            Bullettrail.startColor = Color.red;
            rb.velocity = new Vector2(direction.x,direction.y).normalized * -force * 2;
            gameObject.tag = "Bullet";
        }
         else if (other.gameObject.CompareTag("Untagged"))
         {
            GameObject Dust = Instantiate(BulletDust,this.transform.position,Quaternion.identity);
            Destroy(Dust,1f);
            Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("Enemy")&& defelcted)
        {
            other.GetComponent<Health>().currentHealth -= 100;
            other.GetComponent<Health>().SpawnBlood();
            Destroy(this.gameObject);
        }
    }

}
