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
    [SerializeField] GameObject[] projectiles;
    public int currentProjectile = 0;
    GameObject projectileSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        projectileSpawner = GameObject.Find("Projectle Spawn Point");
        if (projectileSpawner != null)
        {
            Debug.Log("fpund dhild");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        var shooting = Input.GetKeyDown(KeyCode.Space);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot(projectileSpawner.transform.position);
        }
    }

    private void FixedUpdate()
    {
        var OwO = Input.GetKeyDown(KeyCode.Space);
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
        Debug.Log("ran");
        
    }

    void shoot(Vector2 where)
    {
        Instantiate(projectiles[currentProjectile], where, transform.rotation);
    }
}
