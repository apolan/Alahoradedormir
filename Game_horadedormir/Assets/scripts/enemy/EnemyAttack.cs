using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 1.2f;
    public int attackDamage = 1;

    Animator animator;
    GameObject player;
    PlayerHeatlh playerHealth;
    EnemyHealth enemyHealth;
    XInput controller;

    bool playerInRange;
    float timer;
    float lastAttack;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHeatlh>();
        controller = player.GetComponent<XInput>();

        enemyHealth = GetComponent<EnemyHealth>();
        Debug.Log(" player health: " + playerHealth.currentHealth);


        animator = GetComponent<Animator>();
	}


    void OnTriggerEnter(Collider collider) {
        /// Debug.Log("--> Entra collider: " + collider.name);
        if (collider.gameObject == player) {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider collider){
       // Debug.Log("<-- Exit collider: " + collider.name);
        if (collider.gameObject == player)
        {
            playerInRange = false;
        }
    }


    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer >= lastAttack + timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) {
            attack();

            controller.vibratePlayer(Random.Range(0.5f, 1f), Random.Range(0.2f, 1f));
            lastAttack = timer;
        }

        if (playerHealth.currentHealth <= 0) {
           // animator.SetTrigger("PlayerDead");
        }
	}


    void attack() {
        timer = 0f;
        if (playerHealth.currentHealth > 0 ) {
            playerHealth.takeDamage(attackDamage);
        }
    }
}
