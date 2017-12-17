using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    public PlayerHeatlh playerhealth;
    public float restarDelay = 35f;
    Animator animator;
    float restarTimer;
    bool dead;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerhealth.currentHealth <= 0)
        {
            animator.SetTrigger("Gameover");
            if (!dead)
            {
                restarTimer = Time.time + restarDelay;
                dead = true;
            }

            if (Time.time >= restarDelay)
            {
                Application.LoadLevel(Application.loadedLevel);
                dead = false;
            }
        }
        else if (TimeManager.isTime()) {
            Application.LoadLevel("level-win");
        }
	}
}
