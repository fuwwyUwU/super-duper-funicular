using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float rotationSpeed = 200;
    public bool allowMovement;
    public bool moveForward;
    [SerializeField] float movementSpeed = 5;
    float baseMovementSpeed = 5;
    public float bosstedSpeed = 15;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            movementSpeed = bosstedSpeed;
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
            rb.AddForce(Vector2.up * (movementSpeed * Time.deltaTime));
        }

        
        
    }
}
