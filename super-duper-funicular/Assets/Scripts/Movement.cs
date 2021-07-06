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
    bool move;
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

        Application.targetFrameRate = 120;

        controls = new InputMaster();
        controls.Player.Movement.performed += ctx => MovementInputHandler(ctx.ReadValue<float>());
        

    }

    void MovementInputHandler(float where)
    {
        Debug.Log(where);

       if (where != 0)
        {
            move = true;
            rotateDirection = where;
            moveWhere = new Vector3(0, 0, where);
        }
        else
        {
            move = false;
            moveWhere = new Vector3(0, 0, 0);
        }

        


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        //moves the player forward
        
        if (allowMovement)
        {
            transform.Translate(Vector2.up * (movementSpeed * Time.deltaTime));
        }

        if (allowMovement && move)
        {
            transform.Rotate(moveWhere * (rotationSpeed * Time.deltaTime));
        }



    }

   
}