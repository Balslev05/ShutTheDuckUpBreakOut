using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPeck : MonoBehaviour
{
    public GameObject AttackPoint;
    private float timer;
    public float AttackDistance;
    public Vector3 dir;
    private bool DoingAttack = true;
    private Animator enemyAnim;
    private Vector3 movement;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
        enemyAnim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if(distance < AttackDistance && DoingAttack == false)
        {
            enemyAnim.Play("Enemy1Attack");
        }
          
    }

    public void ActivateCollider()
    {
        AttackPoint.SetActive(true);
        DoingAttack = true;
    }
    public void DeactivateCollider()
    {
        AttackPoint.SetActive(false);
        DoingAttack = false;
    }








}
