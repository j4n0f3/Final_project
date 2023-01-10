using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public int defense_cqc;
    public int defense_distace;
    private Levels level;
    // Start is called before the first frame update
    void Start()
    {
        defense_cqc = 100;
        defense_distace = 80;
    }

    // Update is called once per frame
   
    private void Defense_cqc() {
        defense_cqc += defense_cqc + level.level;
    }
    public void Defense_Distance()
    {
        defense_distace += defense_distace + level.level;
    }


}
