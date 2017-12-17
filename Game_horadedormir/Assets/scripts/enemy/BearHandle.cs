using UnityEngine;
using System.Collections;

public class BearHandle : MonoBehaviour {

    Animator animator;
    Rigidbody bearRigidBody;

    private int estado = 0;  // 0: no disparo | 1: disparo

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        bearRigidBody = GetComponent<Rigidbody>();
        //animator

    }

    // Update is called once per frame
    void Update () {

    }
}
