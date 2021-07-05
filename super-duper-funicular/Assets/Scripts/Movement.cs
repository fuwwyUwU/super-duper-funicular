using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float rotationSpeed = 200;
    [SerializeField] int currentAmmo;
    [SerializeField] int maxAmmo = 100;
    [SerializeField] float timeBetweenShoots = 1;
    public bool allowMovement;
    public bool moveForward;
    [SerializeField] float movementSpeed = 5;
    float baseMovementSpeed = 5;
    Rigidbody2D rb;
    [SerializeField] GameObject[] projectile;
    public int currentProjectile = 1;
    GameObject projectileSpawner;
    int ammoCost;
    [SerializeField] bool alloowshoot;
    List<GameObject> shootAt;

    // Start is called before the first frame update
    void Start()
    {
        alloowshoot = true;
        shootAt = new List<GameObject>();

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Projectile Spawnpoint"))
        {

           shootAt.Add(fooObj);
        }
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Application.targetFrameRate = 1;
        }
        else
        {
            Application.targetFrameRate = 60;
        }
        
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeProjectile(0);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeProjectile(1);
        }


        var shooting = Input.GetKey(KeyCode.Space);

        if (!alloowshoot) return;
        else if (shooting)
        {
            
           for (int i = 0; i < GameObject.FindGameObjectsWithTag("Projectile Spawnpoint").Length; i++)
            {
                shoot(shootAt[i].transform.position);
                StartCoroutine(allowProjectile());
                alloowshoot = false;
            }
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

    void shoot(Vector2 where)
    {
        Instantiate(projectile[currentProjectile], where, transform.rotation);
    }

    public void ChangeProjectile(int changeTo)
    {
        currentProjectile = changeTo;
        Projectiles _projectileProperties;
        currentProjectile = changeTo;
        _projectileProperties = projectile[changeTo].gameObject.GetComponent<Projectiles>();
        ProjectileChange(changeTo, _projectileProperties);




    }

    IEnumerator allowProjectile()
    {
        Debug.Log("ran");
        yield return new WaitForSeconds(timeBetweenShoots);
        alloowshoot = true;
    }

    void ProjectileChange(int changeToWhat, Projectiles project)
    {

        ammoCost = project.ammoCost;
        timeBetweenShoots = project.betweenShoots;
    }
}