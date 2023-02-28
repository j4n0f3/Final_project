using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_LifeBar : MonoBehaviour
{
    private GameObject enemy;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemy.transform.position + new Vector3(0, 5, 0);
        gameObject.transform.LookAt(player.transform);
    }
}
