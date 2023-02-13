using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public TMP_Text canvas;
    private int scores;
    private bool win;
    // Start is called before the first frame update
    void Start()
    {
        win = false;
        scores = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (win != true)
        {
            canvas.text = "Score: " + scores;
        }
        if(scores == 4)
        {
            canvas.text = "YOU WIN";
            canvas.transform.position = GameObject.Find("Win").transform.position;
        }
    }
    public void Scoring(int puntos)
    {
        //el enemigo otorgara estos points
        scores += puntos;
    }
    public int Scoring() { return scores; }
}
