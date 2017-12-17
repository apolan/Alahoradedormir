using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public PlayerHeatlh playerHealth;
    public GameObject enemyBear;
    public GameObject enemyBox;
    public GameObject enemyBall;

    public float spawnTime = 15f;
    Light world;

    public Transform[] spawnPoints;

    public ArrayList enemies;
    public bool activeBear;
    public bool activeBall;
    public bool activeBox;

    double timelastSpawn;

    public int level = -1;

    public  int currentEnemy = 0;
    int maxEnemy = 0;
    int createdEnemy = 0;



    // Use this for initialization
    void Start () {
       /* if (spawnPoints.Length > 0) {
            InvokeRepeating("spawn", spawnTime, spawnTime);
        }*/
        enemies = new ArrayList();
        AudioSource audio = GameObject.Find("Dollhouse1").GetComponent<AudioSource>();

        
        maxEnemy = 4;
        currentEnemy = maxEnemy;
        //Debug.Log("Dollhouse1 + " + audio);

        timelastSpawn = Time.time;
        world = GameObject.Find("luna").GetComponent<Light>();

    }

    void spawn(string tag, int index) {
        
        if (tag== "bear"){
            Instantiate(enemyBear, spawnPoints[index].position, spawnPoints[0].rotation);
            enemies.Add(enemyBear);
        }else if (tag == ("box")){
            Instantiate(enemyBox, spawnPoints[index].position, spawnPoints[0].rotation);
            enemies.Add(enemyBox);
        }
        else if (tag == ("ball")){
            Instantiate(enemyBall, spawnPoints[index].position, spawnPoints[0].rotation);
            enemies.Add(enemyBall);
        }
        else if (tag == ("doll"))
        {
            Instantiate(enemyBall, spawnPoints[index].position, spawnPoints[0].rotation);
            enemies.Add(enemyBall);
        }
        else
        {
            Debug.Log("Not find tag: " + tag);
        }

        if (playerHealth.currentHealth <= 0f) {
            return;
        }

        createdEnemy++;

    }


    // Update is called once per frame
    void Update()
    {

        if (currentEnemy == 0)
        {
            Debug.Log("Entra curr");
            increaseDificultad();
            return;
        }// 

        if (createdEnemy == maxEnemy) {
            Debug.Log("Entra enemy");
            return;
        } //  -- hast qui esper

        if (Time.time > timelastSpawn) {

            timelastSpawn = timelastSpawn + spawnTime;
            if (level == -1) // Aqui empieza
            {
                spawn("bear",0);
                spawn("bear", 1);
            }
            else if (level == 0)
            {
                spawn("box",0); // Se manda solo 1
                spawn("box", 1); // Se manda solo 1

            } // - - -  - - - - - - -- - - -  - - - - - - -- - - -  - - - - - - -- - - -  - - - - - - -- - - -  - - - - - - -- 
            else if (level == 1)            {
                spawn("bear",0);
                spawn("box",1);
                spawn("box", 2);
                AudioSource audio2 = GameObject.Find("Dollhouse1").GetComponent<AudioSource>();
                audio2.Play();
            } // - - -  - - - - - - -- - - -  - - - - - - -- - - -  - - - - - - -- - - -  - - - - - - -- - - -  - - - - - - -- 
            else if (level == 2)
            {
                spawn("bear", 0);
                spawn("box",2);
                spawn("box",1);
                spawn("bear",0);
            } // - - -  - - - - - - -- - - -  - - - - - - -- - - -  - - - - - - -- - - -  - - - - - - -- - - -  - - - - - - -- 
            else if (level == 3)
            {

            }


        }
        
    }


    void increaseDificultad() {
        this.level = this.level + 1;
        Debug.Log("Level siguiente " + level);

        if (level == 0){

        }else  if (level == 0) {
            maxEnemy = 15;
            currentEnemy = maxEnemy;
            createdEnemy = 0;
            TimeManager.increaseTime(75);
           // Color color = new Color();
           // ColorUtility.TryParseHtmlString("#2C8DA6FF", out color);
           // world.color = color;
           
        }
        else if (level == 1){
            maxEnemy = 25;
            currentEnemy = maxEnemy;
            createdEnemy = 0;
            TimeManager.increaseTime(45);

        }
        else if (level == 2)
        {
            maxEnemy = 35;
            currentEnemy = maxEnemy;
            createdEnemy = 0;
            TimeManager.increaseTime(35);

        }
        else if (level == 3){
            activeBear = true;
            maxEnemy = 50;
            currentEnemy = maxEnemy;
            createdEnemy = 0;
            TimeManager.increaseTime(75);
        }

       // garbage();
    }
    
    
    void OnGUI()
    {
        string newString = "Level actual: " + level + "  to kill: " +  maxEnemy + "  currentEnemy: " + currentEnemy + " created : " + createdEnemy + " time: " +Time.time + " timelast: " + timelastSpawn;
        GUI.Label(new Rect(10, 10, 500, 100), newString); //Display new values
        // Though, it seems that it outputs the value in percentage O-o I don't know why.
    }

    void garbage() {
        foreach (GameObject i in enemies){
            //DestroyImmediate(i,true);
        }
    }
}
