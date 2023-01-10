using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int cqc;
    public int distance;
    private Levels levels;
    // Start is called before the first frame update
    void Start()
    {
        cqc = 100;
        distance = 150;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CQC() {
        cqc += cqc / levels.level;

    }
    public void Distace() {
        distance += distance / levels.level;
    }
}
