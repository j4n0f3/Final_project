using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool alive;
    private Defense defense;
    private Levels level;
    private Damage damage;

    private void Awake()
    {
        health = 1000;
        alive = true;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
        Stayin_Alive();
        Level_hp();
    }
    private void Level_hp()
    {
        health += health / level.level;
    }
    public int HP_CQC_Dmg(Damage damage)
    {
        health -= damage.cqc - defense.defense_cqc;
        return health;
    }
    public int HP_Distace_Dmg(Damage damage)
    {
        health -= damage.distance - defense.defense_distace;
        return health;
    }

    private void Stayin_Alive()
    {
        if ((health < 1) && (alive == true))
        {
            alive = false;
            //Aca creare la pantalla de muerte
        }
        else
        {//Comprobar que no ocurra una desgracia
            if ((health < 1) && (alive == false))
            {
                Debug.LogError("Fallo en la comprobacion de vida");
            }
        }

    }
    public void Standard_Heal(bool healing)
    {
        if (healing == true)
        {
            while(health < 1000) { health += 10; }
        }
        else
        {
            Debug.Log("Max Health");
        }
    }
    private void rebirth()
    {
        health = 1000;
    }

}
