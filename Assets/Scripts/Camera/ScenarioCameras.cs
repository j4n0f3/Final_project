using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioCameras : MonoBehaviour
{
    [SerializeField] private float delay;
    private float aux;
    [SerializeField] private GameObject first;
    [SerializeField] private GameObject second;
    private bool camState;
    // Start is called before the first frame update
    void Start()
    {
        delay = 2;
        aux = delay;
        camState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > -1)
        {
            delay -= 1 * Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (delay < 1 && camState == true)
            {
                first.SetActive(false);
                second.SetActive(true);
                camState = false;
                delay = aux;
            }
            if (delay < 1 && camState == false)
            {
                first.SetActive(true);
                second.SetActive(false);
                camState = true;
                delay = aux;
            }
        }
        
    }
}
