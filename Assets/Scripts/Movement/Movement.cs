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
    [SerializeField] private Camera cam;
    public Rigidbody rb;
    private void Awake()
    {
        speed *= 100;
        run_speed *= 100;
    }
    private void Start()
    {
        cam = Camera.main;
    }

    void Update() {
        cam = Camera.main;
        //Estado de caminar solamente
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Mouse1))
        {
            SetState(State.walking);
            //Estado de correr
            if (Input.GetKey(KeyCode.LeftShift))
            {
                SetState(State.running);
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            SetState(State.shooting);
        }
        
    }
    //Movimiento normal
    private void Move()
    {
        
        Vector3 base_movement = new(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        rb.velocity = base_movement.normalized * speed * Time.deltaTime;
    }
    //Movimiento corriendo
    private void Run()
    {
        Vector3 base_movement = new (Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        rb.velocity = base_movement.normalized * run_speed * Time.deltaTime;
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

    private void MouseLook()
    {
        Vector3 pjPos = cam.WorldToViewportPoint(transform.position);
        Vector3 mousepos = (Vector2)cam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direccion = mousepos - pjPos;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angulo, 0));
    }
    private void SetState(State currentstate)
    {
        switch (currentstate)
        {
            case State.idle:
                break;
            case State.running:
                Run();
                if (!Input.GetKey(KeyCode.Mouse1))
                {
                    Rotar();
                }
                break;
            case State.shooting:
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Run();
                }
                else
                {
                    Move();
                }
                MouseLook();
                break;
            case State.walking:
                Move(); 
                if (!Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Rotar();
                }
                break;
        }
    }

    
}
