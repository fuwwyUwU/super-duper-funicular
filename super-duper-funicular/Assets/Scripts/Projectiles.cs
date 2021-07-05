using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float killAfter = 3;
    public float ammoCost;
    public float betweenShoots; 
    float time = 0;
    
    
    [SerializeField] float projectileDamage = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // timer for when to destroy the object
        
        time += Time.deltaTime;

        if (time > killAfter)
        {
            Destroy(gameObject);
            
        }

    }

    private void FixedUpdate()
    {
        //moves the projectile
        transform.Translate(Vector2.up * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //gets the health of the object it collided with
        Health _health = collision.gameObject.GetComponent<Health>();
        //logs that it collided
        Debug.Log("collided");

        //checks that the other object has a health class
        if (_health == null) return;
        else
        {
            //if it has a health class it changes the health
            _health.ChangeHealth(projectileDamage);


        }
        
        //destroys itself
        Destroy(gameObject);
    }
}
