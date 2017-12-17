using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 10;
    public int currentHealth;
    private float sinkSpeed= 2.5f;
    private int scoreVALUE = 10;


    public AudioClip deathClip;
    EnemyManager level;

    Animator animator;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    BoxCollider boxCollider;

    bool isdead = false;
    bool isSinking;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        // hitParticles = GetComponent<ParticleSystem>();
        boxCollider = GetComponent<BoxCollider>();
        currentHealth = startingHealth;
        level = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void takeDamage(int amount) {
        if (isdead) {
            return;
        }

        enemyAudio.Play();
        currentHealth -= amount;

        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();

        if (currentHealth <= 0) {
            death();
        }
        Debug.Log("Vida  oso: " + currentHealth);
        ScoreManager.score += Random.Range(15, 30);
    }

    void death() {
        isdead = true;
        //boxCollider.isTrigger = true;
        animator.SetTrigger("dead");
        enemyAudio.clip = deathClip;
        //enemyAudio.Play();
        Destroy(this);
        level.currentEnemy--; 
        TimeManager.increaseTime(Random.Range(1, 5));

    }

    public void startSinking() {
        Debug.Log("--./ start sinking: " );
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        ScoreManager.score += scoreVALUE;
       
    }
}
