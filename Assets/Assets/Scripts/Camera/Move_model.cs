using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_model : MonoBehaviour
{
    private Transform looking;
    private Scores points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            looking = GameObject.Find("Up").transform;
            transform.LookAt(looking);
        }
        if (Input.GetKey("a"))
        {
            looking = GameObject.Find("Left").transform;
            transform.LookAt(looking);
        }
        if (Input.GetKey("s"))
        {
            looking = GameObject.Find("Down").transform;
            transform.LookAt(looking);
        }
        if (Input.GetKey("d"))
        {
            looking = GameObject.Find("Right").transform;
            transform.LookAt(looking);
        }
    }
}
