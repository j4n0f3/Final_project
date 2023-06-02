using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioCameras : CameraColliders
{
    [SerializeField] private Collider puerta;

    private void Update()
    {
    }

    private void OnCollisionEnter()
    {
        if (puerta.gameObject.tag == "Player")
        {
            Debug.Log("Change");
        }
    }
}
