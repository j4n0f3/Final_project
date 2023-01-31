using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Controller : MonoBehaviour
{
    [SerializeField] private int life;
    private int life_aux;
    [SerializeField] private int heal_persecond;

    void Start()
    {
        life_aux = life;
    }
    void Update()
    {
        if (life < 1)
        {
            Destroy(gameObject);
        }
    }
    public int LifeCounter()
    {
        return life;
    }
    public void Heal(int heal)
    {
        life += heal;
    }
    public void BeingDamaged(int damage)
    {
        life -= damage;
    }
    private void OnTriggerStay(Collider other)
    {
        GameObject area = other.gameObject;
        if(gameObject.CompareTag("Player") && area.CompareTag("PJheal"))
        {
            if(life < life_aux) 
            { 
                Heal(heal_persecond); 
            }
        }
        if(gameObject.CompareTag("Enemy") && area.CompareTag("Enemyheal"))
        {
            if(life < life_aux) 
            { 
                Heal(heal_persecond); 
            }
        }
    }
}
