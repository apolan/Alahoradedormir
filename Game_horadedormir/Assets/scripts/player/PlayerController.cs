using UnityEngine;
using System.Collections;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private float lookSensitivity = 2f;

    private PlayerMotor motor;


    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        //int.p

    }



    void Update()
    {
        // calcular movimiento y velocidad como en 3d
        float xMov = Input.GetAxisRaw("Horizontal"); // -1 - 1
        float yMov = Input.GetAxisRaw("Vertical");
        //float zMov = Input.GetAxisRaw("");

        Vector3 movHorizontal = transform.right * xMov ; // (1,0,,0) cuando no nos movemos
        Vector3 movVertival = transform.forward * yMov ; // (0,0,,1) 

        // Final movement vector
        Vector3 velocity = (movHorizontal + movVertival).normalized * speed;

        motor.move(velocity);


        //Calculate rotation as 3d vector: Solo para rotar
        float xRot = Input.GetAxisRaw("Mouse Y");
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;
        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;

        // Apply rotation
        motor.rotate(rotation);
        motor.rotateCamera(cameraRotation);
        //motor.rotateLight(cameraRotation);

        // update light

    }
}

