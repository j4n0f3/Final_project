using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{   
    public int level;
    private Scores score;

    void Start()
    {
        level = 1;
    }

    void Update()
    {
        Leveling();
    }
    private void Leveling()
    {
        level += score.Scoring() / level;
    }
}
