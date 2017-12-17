using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    float timer;
    string path ;
    public MovieTexture movTexture;
    GameObject video;
    Animator animator;
    float time;
    float timesound = 40f;
    bool light;
    AudioSource audio;

    void Start()
    {
        
        Debug.Log("inicio");
        path = Application.dataPath + "/StreamingAssets/";
        Renderer r = GameObject.Find("Plane").GetComponent<Renderer>();
        movTexture = (MovieTexture)r.material.mainTexture;
        audio = GetComponent<AudioSource>();
        animator = GameObject.Find("light").GetComponent<Animator>();
        time = Time.time + timesound;
        audio.Play(); 
    }


    void Update() {
        if (Time.time > time && !light) {
            light =  true;   
                animator.SetTrigger("light");
                movTexture.Play();
            
        }
        if (light && !movTexture.isPlaying) {
            Application.LoadLevel("level-01");
        }       
    }
    
}
