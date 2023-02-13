using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enemy_state
{
    chasing,
    dying

}
public class Enemy : MonoBehaviour
{
    //Movimiento y Rotacion
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float lerptime;
    [SerializeField] private float max_distace;
    [SerializeField] private float min_distace;
    //------------------------------------------------
    //Ataque
    [SerializeField] private GameObject bullet;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Transform cannon;
    [SerializeField] private float delay;
    private float aux_delay;
    [SerializeField] private float redux_delay; //reduccion de delay
    //------------------------------------------------ 
    private int aux;
    //------------------------------------------------
    //Scoring
    private GameObject scores;
    //------------------------------------------------
    void Start()
    {
        scores = GameObject.Find("Hud");
        aux_delay = delay;
        aux = gameObject.GetComponent<Life_Controller>().LifeCounter();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        //Arranca en el estado de persecucion
        E_State(Enemy_state.chasing);
        
        //Constantemente chequea la vida en life controller
        if (gameObject.GetComponent<Life_Controller>().LifeCounter() < aux && gameObject.GetComponent<Life_Controller>().LifeCounter() < 30)
        {
            //En caso de haber perdido demasiada vida, el enemigo huira hasta el area de sanacion mas cercana
            E_State(Enemy_state.dying);
        }
        //Anotando Puntos
        if (gameObject.GetComponent<Life_Controller>().LifeCounter() < 1)
        {
            scores.GetComponent<Scores>().Scoring(1);
        }
    }
    private void Chase()
    {
        //Su movimiento se hara en el vector que apunta al player
        Vector3 newpos = player.transform.position - transform.position;
        float distance = newpos.magnitude; 
        //Checkea si esta a suficiente distancia para moverse
        if (distance > max_distace && distance < min_distace)
        {
            enemyAnimator.SetBool("Chase", true);
            transform.position += newpos.normalized * (speed * Time.deltaTime);
        }
        else
        {
            enemyAnimator.SetBool("Chase", false);
        }
    }
    private void Rotate_Towards_Player()
    {
        //Rota hacia Player suavizado
        Vector3 inicial_rotation = player.transform.position - transform.position;
        Quaternion final_rotation = Quaternion.LookRotation(inicial_rotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, final_rotation, lerptime * speed * Time.deltaTime);
    }
    private void ShootingPlayer()
    {
        Vector3 newpos = player.transform.position - transform.position;
        float distance = newpos.magnitude;
        if(delay > 0)
        {
            delay -= redux_delay * Time.deltaTime;
        }
        if (delay < 1)
        {  
            if (distance < min_distace)
            {
                Instantiate(bullet, cannon);
                enemyAnimator.SetBool("Firing", true);
                delay = aux_delay;
            }
            else 
            {
                enemyAnimator.SetBool("Firing", false);
            }
            
        }
        
    }


    private void E_State(Enemy_state state)
    {
        switch (state)
        {
            case Enemy_state.chasing:
                Chase();
                Rotate_Towards_Player();
                ShootingPlayer();
                break;
            case Enemy_state.dying:
                break;
        }
    }
}
