using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<Health>().currentHealth == Player.GetComponent<Health>().maxHealth)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        } else{ GetComponent<CircleCollider2D>().enabled = true;}
    }
   public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
           collider.GetComponent<Health>().currentHealth = 10;
           Destroy(this.gameObject);
        }
    } 
}


