using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_2 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float max_distance;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newrotation = player.transform.position - transform.position;

        float distance = newrotation.magnitude;
        if (distance > max_distance)
        {
            transform.position += newrotation.normalized * (speed * Time.deltaTime);
        }
        
    }
}
