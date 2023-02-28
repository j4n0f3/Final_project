using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Controller : MonoBehaviour
{
    [SerializeField] private int life;
    private int max_life;
    [SerializeField] private Slider healthbar;


    void Start()
    {
        max_life = life;
    }
    void Update()
    {
        healthbar.maxValue = max_life;
        healthbar.value = life;

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
