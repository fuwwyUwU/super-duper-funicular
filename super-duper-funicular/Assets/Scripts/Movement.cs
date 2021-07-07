using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    public float rotationSpeed = 200;
    public bool allowMovement;
    public bool moveForward;
    public  float movementSpeed = 5;
    float baseMovementSpeed = 5;
    public InputMaster controls;
    Vector3 moveWhere;
    float rotateDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    private void Awake()
    {
        controls = new InputMaster();
        controls.Player.Movement.performed += ctx => MovementInputHandler(ctx.ReadValue<float>());



    }

    void MovementInputHandler(float where)
    {



    }

    void Test(float flo)
    {
        Debug.Log(flo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        //moves the player forward

        float currentRotation = controls.Player.Movement.ReadValue<float>();
        Vector3 moveWith= new Vector3(0, 0, currentRotation);
        
        if (allowMovement)
        {
            transform.Translate(Vector2.up * (movementSpeed * Time.deltaTime));
        }

        if (allowMovement)
        {
            transform.Rotate((moveWith).normalized * (rotationSpeed * Time.deltaTime));
            Debug.Log((moveWith).normalized);
        }



    }

   
}