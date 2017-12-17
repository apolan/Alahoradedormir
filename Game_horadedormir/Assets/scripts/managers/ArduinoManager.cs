using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;

public class ArduinoManager : MonoBehaviour
{


    SerialPort stream = new SerialPort("COM5", 115200);

    //  [0] - x | [1] - y | [2] - z : Guarda los grados
    float[] lastRot = { 0, 0, 0 };
    float[] currentRot = { 0, 0, 0 }; 

    double lastTime;
    double calibrarTime = 1f;
    Boolean calibrar = false;

    float umbral = 1f;

    void Start()
    {
        stream.Open(); //Open the Serial Stream.
        stream.BaseStream.ReadTimeout = 30;
        //stream.StopBits=StopBits.Two;
        lastTime = Time.deltaTime;
        calibrarTime = Time.time + calibrarTime;
        calibrar = false;
    }

    // Update is called once per frame
    void Update(){
            readLine(); 
    }

    void readLine() {
        //stream.Open();
        lastTime = Time.time;

        try{           
            string value = stream.ReadLine(); //Read the information
           
            if (value.Split(';').Length > 1){ 
                string[] vec3 = value.Split(';'); //My arduino script returns a 3 part value (IE: 12,30,18)
                
                currentRot[0] = float.Parse(vec3[0]);
                currentRot[1] = float.Parse(vec3[1]);
                currentRot[2] = float.Parse(vec3[2]);

                // Se hace la calibracion inicial
                if (!calibrar && Time.time <= calibrarTime) {
                    lastRot[0] = currentRot[0];  
                    lastRot[1] = currentRot[1];
                    lastRot[2] = currentRot[2];
                    return;
                }

                    calibrar = true;

                //Debug.Log("x curr:" + currentRot[0] +  " x last:" + lastRot[0] + " cambio: " + (lastRot[0] - currentRot[0]));
                Debug.Log("x curr:" + currentRot[1] + " x last:" + lastRot[1] + " cambio: " + (lastRot[1] - currentRot[1]));
                //Debug.Log("x curr:" + currentRot[2] + " x last:" + lastRot[2] + " cambio: " + (lastRot[2] - currentRot[2]));

                // Y -> X se hace el check por cada componente Y
                if (Mathf.Abs(lastRot[1] - currentRot[1]) > umbral) {
                    transform.Rotate(
                        0,
                        (currentRot[1]) * -0.8f,
                        0,
                        Space.Self
                        );
                }

                // X -> Y se hace el check por cada componente X
               /*if (Mathf.Abs(lastRot[0] - currentRot[0]) > umbral){
                    transform.Rotate(
                        (currentRot[0]),
                        0,
                        0,
                        Space.Self
                        );
                }
                /*
                // Z: se hace el check por cada componente
                if ((lastRot[2] - currentRot[2]) > 1){
                    transform.Rotate(
                        0,
                        0,
                        (currentRot[2] - lastRot[2]),
                        Space.Self
                        );
                }*/

                // Se guarda siempre la posicion anterior
                lastRot[0] = currentRot[0];
                lastRot[1] = currentRot[1];
                lastRot[2] = currentRot[2];

                 //Clear the serial information so we assure we get new information.
            }
            stream.BaseStream.Flush();

        }
        catch (Exception a) {
            Debug.Log("Error Arduino: " + a.ToString() );
        }
    }

    
    void OnGUI()
    {
        string newString = "Connected: 0-" + currentRot[0] + ", 1-" + currentRot[1] + ", 2-" + currentRot[2] + " TIME " + Time.time;
        GUI.Label(new Rect(10, 10, 300, 100), newString); //Display new values
        // Though, it seems that it outputs the value in percentage O-o I don't know why.
    }

    
}