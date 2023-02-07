using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum animstate
{
    moving,
    stoping,
    shooting,
    aiming,
    dying
}

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator pjAnim;
    [SerializeField] private float speed;
    [SerializeField] private float run_speed;
    private float life;

    // Start is called before the first frame update
    void Start()
    {
        life = gameObject.GetComponent<Life_Controller>().LifeCounter();
    }

    // Update is called once per frame
    void Update()
    {
        //Caminando
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            SetAnimState(animstate.moving);
        }
        //-----------------------------------------------------------------------------------------------------------
        else
        {
        //Frenando
            SetAnimState(animstate.stoping);
        //-----------------------------------------------------------------------------------------------------------
        }
        //Apunando
        if (Input.GetKey(KeyCode.Mouse1))
        {
            SetAnimState(animstate.aiming);
            //-----------------------------------------------------------------------------------------------------------  
            //Disparando
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SetAnimState(animstate.shooting);

            }
            else
            {
                pjAnim.SetBool("fire", false);
            }

            //-----------------------------------------------------------------------------------------------------------
        }
        else
        {
            pjAnim.SetBool("aim", false);
        }

        
        //Muriendo
        if (life < 1)
        {
            SetAnimState(animstate.dying);
        }
        //-----------------------------------------------------------------------------------------------------------
    }

    private void SetAnimState(animstate state)
    {
        switch (state)
        {
            case animstate.moving:
                //CODE Caminando
                pjAnim.SetFloat("speed", speed);
                //-----------------------------------------------------------------------------------------------------------
                //CODE Corriendo
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    pjAnim.SetFloat("speed", run_speed);
                }
                //-----------------------------------------------------------------------------------------------------------
                break;
            case animstate.stoping:
                //CODE Frenando
                pjAnim.SetFloat("speed", 0);
                //-----------------------------------------------------------------------------------------------------------
                break;

            case animstate.aiming:
                //CODE Apuntando
                pjAnim.SetBool("aim", true);
                //-----------------------------------------------------------------------------------------------------------
                break;
            case animstate.shooting:
                //CODE Disparando
                pjAnim.SetBool("fire", true);
                //-----------------------------------------------------------------------------------------------------------
                break;

            case animstate.dying:
                //CODE Muriendo
                pjAnim.SetTrigger("isalive");
                break;
                //-----------------------------------------------------------------------------------------------------------
        }
    }
}
