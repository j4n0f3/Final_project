using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public TMP_Text canvas;
    private int scores;
    // Start is called before the first frame update
    void Start()
    {
        scores = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        canvas.text = "Score: " + scores;
    }
    public void Scoring(int puntos)
    {
        //el enemigo otorgara estos points
        scores += puntos;
    }
    public int Scoring() { return scores; }
}
