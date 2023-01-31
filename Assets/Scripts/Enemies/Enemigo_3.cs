using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Estado_enemigo
{
    looking,
    chasing
}
public class Enemigo_3 : MonoBehaviour
{
    [SerializeField] private Estado_enemigo state;
    [SerializeField] private GameObject player;
    [SerializeField] private float lerp_time;
    [SerializeField] private float max_distance;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Set_estado(state);
    }
    private void Movimiento()
    {
        Vector3 newrotation = player.transform.position - transform.position;

        float distance = newrotation.magnitude;
        if (distance > max_distance)
        {
            transform.position += newrotation.normalized * (speed * Time.deltaTime);
        }
    }
    private void Apuntando()
    {
        Vector3 newrotation = player.transform.position - transform.position;
        Quaternion final_rotation = Quaternion.LookRotation(newrotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, final_rotation.normalized, lerp_time * Time.deltaTime);
    }
    private void Set_estado(Estado_enemigo estado)
    {
        switch (estado)
        {
            case Estado_enemigo.looking:
                Apuntando();
                break;
            case Estado_enemigo.chasing:
                Movimiento();
                break;
        }
    }
}
