
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    public float Shots;
    private GameObject player;
    public bool Shooting = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {

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
}
