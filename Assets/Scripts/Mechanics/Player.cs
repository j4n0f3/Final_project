using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform cannon;
    [SerializeField] private float delay_bullet;
    private float aux_delay;
    [SerializeField] private float time_delay_redux;

    // Start is called before the first frame update
    void Start()
    {
        aux_delay = delay_bullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay_bullet > 0)
        {
            delay_bullet -= time_delay_redux * Time.deltaTime;
        }
        
        if (delay_bullet < 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                Shoot();
                delay_bullet = aux_delay;
            }
        }
        Debug.DrawRay(cannon.position, cannon.forward, Color.red);
    }


    private void Shoot()
    {
        Instantiate(bullet, cannon);
    }
}
