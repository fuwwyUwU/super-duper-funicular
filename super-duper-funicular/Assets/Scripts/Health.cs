using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health;
    float testhealth;
    [SerializeField] float maxHealth = 5;
    float testheath2;

    private void Awake()
    {
        health = maxHealth;
        Application.targetFrameRate = 1;
        InvokeRepeating("DPS", 1, 1);   
    }

    public void ChangeHealth(float changeHealthWith)
    {
        health -= changeHealthWith;

        if (health <= 0) Destroy(gameObject);
    }

    void DPS()
    {
        testheath2 = health;
        testheath2 -= testhealth;
        Debug.Log(testheath2);
         testhealth = health;
    }


}
