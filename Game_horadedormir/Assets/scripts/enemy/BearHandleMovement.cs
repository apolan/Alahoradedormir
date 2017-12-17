using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class BearHandleMovement : MonoBehaviour {

    Transform player;
    // Use this for initialization
    PlayerHeatlh playerhealth;
    EnemyHealth enemyhealth;
    NavMeshAgent nav;
    double timeAnimation;
    EnemyManager level;
    Animator animator;
    bool look;
    EnemyAttack enemyAttack;

    void Start () {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        playerhealth = player.GetComponent<PlayerHeatlh>();
        enemyhealth = GetComponent<EnemyHealth>();
        timeAnimation = Time.time;
        level = GameObject.Find("EnemyManager").GetComponent<EnemyManager>() ;
        enemyAttack = GetComponent<EnemyAttack>();

        if (level.level == 0) {
            nav.speed = 1;
        }
        else if (level.level == 1)
        {
            enemyAttack.attackDamage = 10;
            nav.speed = 2;
        }
        if (level.level == 2)
        {
            enemyAttack.attackDamage = 20;
            nav.speed = 3;
        }

    }

    // Update is called once per frame
    void Update() {
        try{
            /*if (level.level == -1 && !look && nav.enabled) {
                look = true;
                nav.SetDestination(player.position);
                animator.SetTrigger("look");
                //nav.enabled = false;

                return;
            }*/
            if (enemyhealth.currentHealth > 0 && playerhealth.currentHealth > 0 && !look) {
                if (nav != null)
                {
                    nav.SetDestination(player.position);
                }
                else {
                    Destroy(this);
                }
                
            }
            else
            {
                nav.enabled = false;
            }
        }catch (Exception ){
            GetComponent<NavMeshAgent>().enabled = false;
            Destroy(this);
        }
    }
}
