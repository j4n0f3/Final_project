using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Controller : MonoBehaviour
{
    [SerializeField] private int life;

    void Start()
    {
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
}
