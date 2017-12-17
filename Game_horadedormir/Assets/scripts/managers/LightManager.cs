using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour {
    public Light area;
    public Light linterna;
    Animator animator;

    string stateLight = "night";
    int intesity = 0;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        //changeTime("",1);
    }

    /*
    void changeTime(string estado, int intensity) {
        if (estado == "night"){
            if (intensity == 1) {
                animator.SetTrigger(estado +"_"+intensity);
            }
        }
        else if (estado == ("day"))
        {
            
        }
        else
        {
            Debug.Log("Not find animation light" + estado);
        }
    }*/
}
