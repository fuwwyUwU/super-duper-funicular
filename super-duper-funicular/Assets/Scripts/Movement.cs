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

    }

    private void FixedUpdate()
    {

    }
}
