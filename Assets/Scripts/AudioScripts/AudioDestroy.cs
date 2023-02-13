using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDestroy : MonoBehaviour
{
    [SerializeField] private float audioLifetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioLifetime -= 1 * Time.deltaTime;
        if (audioLifetime < 0)
        {
            Destroy(gameObject);
        }
    }
}
