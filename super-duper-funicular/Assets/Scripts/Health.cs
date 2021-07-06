using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health;
    float timeBefore;
    public float maxHealth = 5;
    float timeAfter;

    private void Awake()
    {
        //sets the health to your maxhealth
        health = maxHealth;
        //updates the dps every second
        InvokeRepeating("DPS", 1, 1);   
    }

    public void ChangeHealth(float changeHealthWith)
    {
        health -= changeHealthWith;

        if (health <= 0) Destroy(gameObject);
    }

    //calulates dps
    void DPS()
    {
        //health from this second
        timeBefore = health;
        //current health minus health from last second
        timeBefore -= timeAfter;
        //logs the dps

        //sets the health for the next second 
        timeAfter = health;
    }


}
