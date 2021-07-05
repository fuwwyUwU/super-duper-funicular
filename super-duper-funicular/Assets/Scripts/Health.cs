using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health;
    [SerializeField] float maxHealth = 5;

    private void Awake()
    {
        health = maxHealth;
    }

    public void ChangeHealth(float changeHealthWith)
    {
        health -= changeHealthWith;
        Debug.Log("New health " + health + "/" + maxHealth);

        if (health <= 0) Destroy(gameObject);
    }


}
