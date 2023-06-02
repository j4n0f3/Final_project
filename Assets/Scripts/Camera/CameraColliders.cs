using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliders : MonoBehaviour
{
    protected bool actividad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            actividad = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            actividad = false;
        }
    }
}
