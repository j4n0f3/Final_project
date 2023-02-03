using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       RayOnMouse(Input.mousePosition);
    }

    private void RayOnMouse(Vector3 mousepos)
    {
        Ray rayo = cam.ScreenPointToRay(mousepos);

        if (Physics.Raycast(rayo, out RaycastHit info))
        {
            Vector3 movepos= new Vector3(info.point.x, 1, info.point.z);
            transform.position = movepos.normalized;
        }
    }
}
