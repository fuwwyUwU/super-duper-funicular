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
    CharacterController _cc;
    Vector3 moveWith;
    float shoot;
    Shooting _shootingScript;
    float reload;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Move()
    {
        
        
            transform.Rotate((moveWith).normalized * (rotationSpeed * Time.deltaTime)); 
        
    }

    void OnMovement(InputValue value)
    {
        Vector2 currentRotation = value.Get<Vector2>();
        float currentRotationFloat = currentRotation.x;
        moveWith = new Vector3(0, 0, -currentRotationFloat);


    }

    void OnShoot(InputValue value)
    {
        
        shoot = value.Get<float>();
    }

    void OnReload(InputValue value)
    {

        reload = value.Get<float>();
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
        _shootingScript = GetComponent<Shooting>();
    }


    // Update is called once per frame
    void Update()
    {
        if (shoot != 0)
        {
            _shootingScript.shooting = true;
        }
        else
        {
            _shootingScript.shooting = false;
        }

        if (reload != 0)
        {
            _shootingScript.reloading = true;
        }
        else
        {
            _shootingScript.reloading = false;
        }
    }

    private void FixedUpdate()
    {

        //moves the player forward

        
        if (allowMovement)
        {
            transform.Translate(Vector2.up * (movementSpeed * Time.deltaTime));
            Move();
        }




    }

   
}