using UnityEngine;
using System.Collections;

public class HomeManager : MonoBehaviour {
    AudioSource soundInit;
    float timePlay;
    bool level;
    int levelLoad;
    Animator animator;

    void Start() {
        
        soundInit = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Time.time > timePlay && level){
            Application.LoadLevel(levelLoad);
        }
    }

    public void loadScene(int levelLoad) {
        soundInit.Play();
        this.levelLoad = levelLoad;
        level = true;
        animator.SetTrigger("black");
        timePlay = Time.time + 3.5f;
    }

}
