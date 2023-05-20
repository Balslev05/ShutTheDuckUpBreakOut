using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlertet : MonoBehaviour
{

    public Pathfinding.AIPath AIBrain;
    public Player PlayerMechanics;
    
    public Enemy1Ai AttackAi;

    public Wandering  wandering;

    void Update()
    {
        if(PlayerMechanics.Heat == true)
        {
            AttackAi.enabled = true;

            this.gameObject.GetComponent<Collider2D>().enabled = true;

            wandering.enabled = false;

            AIBrain.enabled = true;
        } else{
            AIBrain.enabled = false; 
            
            AttackAi.enabled = false;

            wandering.enabled = true;

            this.gameObject.GetComponent<Collider2D>().enabled = false;

        }
    }
}
