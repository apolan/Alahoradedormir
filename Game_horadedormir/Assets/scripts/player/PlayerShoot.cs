using UnityEngine;


public class PlayerShoot : MonoBehaviour {

    
    // Time 
    private double nextActionTime = 0.0f;
    public float periodAnimation = 0.2f;
    public float timeBetweenBullets = 0.5f;
    float timer;
    float lastAttack;

    public int damaePershot = 20;
    // Variables shoot
    public GameObject BulletEmitter; // Es de donde sale

    public GameObject Bullet; // Es el prefab
    public GameObject Bullet1; // Es el prefab
    public GameObject Bullet2; // Es el prefab
    public GameObject Bullet3; // Es el prefab


    public float speedBullet;
    private int estado = 0;  // 0: no disparo | 1: disparo 
    public PlayerWeapon weapon;

    Animator animator;

    [SerializeField]
    public Camera cam;

    [SerializeField]
    private LayerMask mask;
    // Use this for initialization
    void Start(){
    animator = GetComponent<Animator>();
    if (cam == null){
               Debug.LogError("Error camera reference playshoot!");
                // this.enabled = false;

       }
   }

   // Update is called once per frame
   void Update(){
        timer += Time.deltaTime;

        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("tirar")) {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0)) {
            animator.SetInteger("state", 0);
            estado = 0;
        }


        // Se actualizan los componentes
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space) && estado == 0 ){
            animator.SetInteger("state", 1);
            estado = 1;
            
            nextActionTime = Time.time + 0.8f;
            lastAttack = timer;
        }


      if (Time.time > nextActionTime  && estado == 1){
            estado = 2;
            //nextActionTime = Time.time + 0.2f;
        }

       // Debug.Log("nextActionTime: " + nextActionTime + " - Time " + Time.time);

    }

    void shoot(){
        Debug.Log("Shoot .. " ); 
       
        int rnda = Random.Range(1, 3);
        Debug.Log(rnda);
        GameObject _tmpBullet = null;

        if (rnda == 1) {
            _tmpBullet = Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;
        }
        else if (rnda == 2)
        {
            _tmpBullet = Instantiate(Bullet1, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;
        }

        // GameObject  _tmpBullet = Instantiate (Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;
        Rigidbody _tmpBulletBody = _tmpBullet.GetComponent <Rigidbody>();
        AudioSource audio = _tmpBullet.GetComponent<AudioSource>();
        _tmpBulletBody.AddForce(transform.forward * speedBullet);
        /*if (hit.collider != null) {
            if (hit.collider.tag != "enemy")
            {
                Destroy(_tmpBullet, 5f);
            }
        }*/
    }
}
