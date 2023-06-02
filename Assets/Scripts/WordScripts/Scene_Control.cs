using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Control : MonoBehaviour
{

    public void Loadscene(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
