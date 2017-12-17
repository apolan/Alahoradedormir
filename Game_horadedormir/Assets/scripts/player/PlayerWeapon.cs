using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerWeapon : MonoBehaviour {

    public GameObject gamecomponente; 

    public string type = "zapato"; //  libro | zapato | reloj |  almohada

    public float damage = 10f;

    public float range = 200f;

    void start() {
        // Se sabe que tipo de objeto es
        if (type == "zapato") {
            int rnd = Random.Range(1, 3);
            Material libromaterial;
            GetComponent<Material>();
            if (rnd == 1) {
                libromaterial = Resources.Load("materials/book-y", typeof(Material)) as Material;

            } else if (rnd == 2){

            }else if (rnd == 3){

            }
            
        }else if (type == "zapato"){

        }else if (type == "libro"){

        }else if (type == "reloj"){

        }else if (type == "almohada"){

        }
    }

}
