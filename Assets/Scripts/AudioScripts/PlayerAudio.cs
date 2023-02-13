using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private GameObject stepsAudio;
    [SerializeField] private AudioSource fireAudio;
    private float delay;

    // Start is called before the first frame update
    void Start()
    {
        delay = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0)
        {
            delay -= 1 * Time.deltaTime;
        }
        
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            stepsAudio.SetActive(true);
        }
        else
        {
            stepsAudio.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (delay < 1)
            {
                fireAudio.Play();
                delay = 2;
            }
        }
        else
        {
            if (!fireAudio.isPlaying)
            {
                fireAudio.Stop();
            }
            
        }
            
    }
}
