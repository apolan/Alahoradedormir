using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private Light linterna;

    [SerializeField]
    private GameObject puntoLanzamiento;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 rotationCamera = Vector3.zero;


    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //interna = GetComponent("linterna") as Light;
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void move(Vector3 velocity)
    {
        this.velocity = velocity;

    }


    public void rotate(Vector3 rotation)
    {
        this.rotation = rotation;
    }

    public void rotateCamera(Vector3 rotationCamera)
    {
        this.rotationCamera = rotationCamera;
    }


    // Run interactions
    void FixedUpdate()
    {
        // Perform movement based on velocity variable
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); // Mueve el rb hasta l posicion mas el vetor velocidad
        }
    }


    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation)); // Coordenadas
        if (camera != null)
        {
            camera.transform.Rotate(-rotationCamera);
        }
        if (linterna != null)
        {
            linterna.transform.Rotate(-rotationCamera);
        }
        if (puntoLanzamiento != null)
        {
            puntoLanzamiento.transform.Rotate(-rotationCamera);
        }

    }


}
