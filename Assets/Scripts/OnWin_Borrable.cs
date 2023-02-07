using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWin_Borrable : MonoBehaviour
{
    private float delay;
    private float aux;
    // Start is called before the first frame update
    void Start()
    {
        delay = 5;
        aux = delay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            delay -= 1 *Time.deltaTime;
            if (delay < 1)
            {
                Destroy(gameObject);
                Debug.Log("Ganaste");
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        delay = aux;
    }
}
