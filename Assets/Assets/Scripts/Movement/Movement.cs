using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f; //Velocidad de movimiento
    public float run_speed = 50.0f;//Velocidad de movimiento al correr
    public float salto = 8.0F; //Velocidad de rotación 
    public Rigidbody rb;
    public GameObject player;
    private void Start()
    {
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, Input.GetAxis("Vertical") * run_speed * Time.deltaTime);
            transform.Translate(Input.GetAxis("Horizontal") * run_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
            transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        }
        
        
    }

    
}
