using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float lifeTime;
    float creationTime;
    public int damaePershot = 20;
    BoxCollider box;
    Rigidbody body;
    AudioSource audioFall;
    // Use this for initialization
    void Start () {
        creationTime = Time.time;
        audioFall = GetComponent<AudioSource>();
        box = GetComponent<BoxCollider>();
        body = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > creationTime + lifeTime) {
            destroyMe();
        }

    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Quien: " + name + "  le casco a " + col.gameObject.tag);
        EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
        audioFall.Play();
        if (col.gameObject.tag == "enemy")
        {
            if (enemyHealth != null)
            {
                enemyHealth.takeDamage(damaePershot);
                if (enemyHealth.currentHealth < 0)
                {
                    //Destroy(hit.collider.gameObject);
                }

            }
        }
        else if (col.gameObject.tag == "environment")        {
            //BoxCollider box = col.gameObject.GetComponent<BoxCollider>();
            //box.enabled = false;
            //body.useGravity = false;

        }
    }


    void destroyMe() {
        Destroy(this.gameObject);
        //Debug.Log("Se destruyo " + name);
    }
}
