using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_1 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float lerp_time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newrotation =  player.transform.position - transform.position;
        Quaternion final_rotation = Quaternion.LookRotation(newrotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, final_rotation, lerp_time);
    }
}
