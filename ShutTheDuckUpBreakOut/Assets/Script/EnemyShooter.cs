
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class EnemyShooter : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;
    public Pathfinding.AIPath AIBrain;
    private float timer;
    public float Shots;
    public GameObject arms;
    public bool Shooting = false;
    private GameObject player;
    private bool LoosingArmor = false;
    private bool LostArmor = false;
    public int DeathScenario;
    public Health health;
    public AIRotate rotat;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true)
        {
            return;
        }
        if(health.currentHealth <= 0)
        {
            death();
        }

        if(LoosingArmor == true)
        {
            return;
        }
        if(LostArmor == true)
        {
            GetComponent<Animator>().Play("Running");
        } else
        {
            GetComponent<Animator>().Play("ArmorRunning");

        }

        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        

        if(distance < 10)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                if(Shooting ==false)
                {
                StartCoroutine(shoot());
                }
            }
        }
    }
    public IEnumerator shoot()
    {
        for (int i = 0; i < Shots; i++)
        {
            Shooting = true;
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }
        timer = 0;
        Shooting = false;

    }
     public void LosingArmor()
    {
        GetComponent<Collider2D>().enabled = false;
        arms.SetActive(false);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        LoosingArmor = true;
        arms.SetActive(false);
    }
     public void ArmorLost()
    {
        GetComponent<Collider2D>().enabled = true;
        arms.SetActive(true);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        LostArmor = true;
        arms.SetActive(true);
        LoosingArmor = false;

    }
    public void death()
    {
        AIBrain.enabled = false;

        isDead = true;
        rotat.enabled = false;
        DeathScenario = Random.Range(1,5);

        if(DeathScenario == 4)
        {
            Destroy(gameObject);
        }
         if(DeathScenario == 3)
        {
            Destroy(gameObject);
        }
        
        GetComponent<Animator>().Play("Dead" + DeathScenario);
        print("death" + DeathScenario);
        
        arms.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        
        transform.GetComponent<SpriteRenderer>().DOFade(0,6).SetEase(Ease.InCirc);
        Destroy(this.gameObject,7f);

    }
}
