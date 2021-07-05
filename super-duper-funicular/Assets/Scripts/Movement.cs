using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    float rotationSpeed = 200;
    public bool allowMovement;
    public bool moveForward;
    [SerializeField] float movementSpeed = 5;
    float baseMovementSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Awake()
    {

        Application.targetFrameRate = 60;


    }

    // Update is called once per frame
    void Update()
    {

        var restart = Input.GetKeyDown(KeyCode.Tab);
        
        if (restart)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);    
        }

           

    }

    private void FixedUpdate()
    {
        var right = Input.GetKey(KeyCode.D);
        var left = Input.GetKey(KeyCode.A);



        transform.Translate(Vector2.up * (movementSpeed * Time.deltaTime));


        if (right)
        {
            transform.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));
        }
        else if (left)
        {
            transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
        }

    }

   
}