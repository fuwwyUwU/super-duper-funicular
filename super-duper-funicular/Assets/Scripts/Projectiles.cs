using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    float speed = 8;
    float killAfter = 3;
    float time = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (time > killAfter)
        {
            Destroy(gameObject);
            
        }

        Debug.Log(time);


    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * (speed * Time.deltaTime));
    }
}
