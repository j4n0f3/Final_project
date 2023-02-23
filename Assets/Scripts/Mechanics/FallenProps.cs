using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenProps : MonoBehaviour
{
    float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 5;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= 1 * Time.deltaTime;
        if(lifetime < 1)
        {
            Destroy(gameObject);
        }
    }

}
