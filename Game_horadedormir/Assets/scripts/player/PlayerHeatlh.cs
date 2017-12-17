using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHeatlh : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImager;
    public AudioClip deathClip;
    private float flashSpeed = 0.5f;
    public Color flashColor = new Color (1f, 0f,0f,0.1f) ;

    Animator animator;
    AudioSource playerAudio;

    bool isDead;
    bool isDamaged;



    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
        Debug.Log("--> INIT PLAYER: " + currentHealth);

    }

    // Update is called once per frame
    void Update () {
        if (isDamaged) {
            damageImager.color = flashColor;
        }
        else{
            damageImager.color = Color.Lerp(damageImager.color,Color.clear,flashSpeed*Time.deltaTime);

        }
        isDamaged = false;
    }

    public void takeDamage(int amount) {
        Debug.Log("-----| dano: usuario" + currentHealth);

        isDamaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        //playerAudio.Play();
        if (currentHealth <= 0 && !isDead) {
            death();
        }
    }

    void death() {
        isDead = true;
        animator.SetTrigger("die");
        // playerAudio.clip = deathClip;
        // playerAudio.Play();
        /*GameObject perder = GameObject.FindGameObjectWithTag("perder");
        perder.GetComponent<GameObject>().enabled = false;
        perder.SetActive(true); */

    }
}
