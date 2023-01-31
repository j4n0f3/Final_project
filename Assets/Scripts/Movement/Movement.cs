using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State{
    idle,
    walking,
    running,
    shooting
}
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed; //Velocidad de movimiento
    [SerializeField] private float run_speed;//Velocidad de movimiento al correr

    public Rigidbody rb;
    private void Start()
    {
    }

    void Update() {
        //Estado de caminar solamente
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            SetState(State.walking);
            //Estado de correr
            if (Input.GetKey(KeyCode.LeftShift))
            {
                SetState(State.running);
            }
        }
        
        
    }
    //Movimiento normal
    private void Move()
    {
        Vector3 base_movement = new(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        transform.position += base_movement.normalized * (speed * Time.deltaTime);
    }
    //Movimiento corriendo
    private void Run()
    {
        Vector3 base_movement = new (Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        transform.position += base_movement.normalized * (run_speed * Time.deltaTime);
    }
    private void Rotar()
    {
        /*
            Primero tomo las direcciones por separado y hago el calculo entre ambas, ya que
            si se apreta solo el eje X positivo sera 1.0f o negativo -1.0f pero Z sera 0.0f.
            Por otro lado, con dos ejes apretados apuntara al termino medio entre X y Z (X= 1.0, Z=-1.0)
            Da como resultado que apunte hacia el noroeste
        */
        Vector3 base_movement_A = new(0, 0, Input.GetAxis("Vertical"));
        Vector3 base_movement_B = new(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 new_rotation = base_movement_A - base_movement_B;
        transform.rotation = Quaternion.LookRotation(new_rotation.normalized);
        
    }
    private void SetState(State currentstate)
    {
        switch (currentstate)
        {
            case State.idle:
                break;
            case State.running:
                Run();
                Rotar();
                break;
            case State.shooting:
                break;
            case State.walking:
                Move();
                Rotar();
                break;
        }
    }

    
}
