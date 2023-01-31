using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Control : MonoBehaviour
{
    public Scene escena;
    public void loadscene()
    {
        SceneManager.SetActiveScene(escena);
    }
}
