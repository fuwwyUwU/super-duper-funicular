using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float rotationSpeed = 200;
    public bool allowMovement;
    public bool moveForward;
    float movementSpeed = 5;
    float baseMovementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            movementSpeed *= 1.5f;
        }
        else
        {
            movementSpeed = baseMovementSpeed;
        }
    }

    private void FixedUpdate()
    {
        var rotate = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || allowMovement;
        var move = moveForward || allowMovement;

        if (rotate)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));
            }

        }

        if (move)
        {
            transform.Translate(Vector2.up * (movementSpeed * Time.deltaTime));
        }

        
        
    }
}
