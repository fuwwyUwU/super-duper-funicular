using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shooting : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI ammoScreen;
    Rigidbody2D _rb;
    [SerializeField] GameObject[] projectile;
    public int currentProjectile = 1;
    [SerializeField] float ammoCost;
    List<GameObject> shootAt;
    [SerializeField] float currentAmmo;
    [SerializeField] int maxAmmo = 100;
    [SerializeField] float timeBetweenShoots = 1;
    float timeToReload = 0;
    [SerializeField] bool alloowshoot;
    // Start is called before the first frame update
    void Start()
    {
        //allows you to shoot
        alloowshoot = true;
        //creats a list of positions where do projectiles will be instansiated
        shootAt = new List<GameObject>();

        //adds all the locations it can be instansiated at
        foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("Projectile Spawnpoint"))
        {

            shootAt.Add(spawnPoint );

        }

        //fills up the ammo
        currentAmmo = maxAmmo;

        //changes the projectile
        ChangeProjectile(currentProjectile);
    }

    // Update is called once per frame
    void Update()
    {
        //sets rp the to rigidbody2d
        _rb = GetComponent<Rigidbody2D>();
        
        //reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload(timeToReload, maxAmmo));
        }

        //changes the projectile (WIP)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeProjectile(0);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeProjectile(1);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            ChangeProjectile(2);
        }

        //checks if u are shooting
        var shooting = Input.GetKey(KeyCode.Space);

        //if you are pressing space, shoot
        if (!alloowshoot) return;
        else if (shooting && currentAmmo >= ammoCost) //checks if you have enougth ammo to shoot
        {

            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Projectile Spawnpoint").Length; i++)
            {
                //shoots a projectile att every projectile spawnpoint
                shoot(shootAt[i].transform.position);
                StartCoroutine(allowProjectile());
                alloowshoot = false;
            }
            //remvoes the ammo you spend
            currentAmmo -= ammoCost;
        }

        //updates the ammo counter
        ammoScreen.text = "Ammo: " + currentAmmo;
    }

    void shoot(Vector2 where)
    {
        //instaniates the projectile
        Instantiate(projectile[currentProjectile], where, transform.rotation);
    }

    //changes your projectile
    public void ChangeProjectile(int changeTo)
    {
        currentProjectile = changeTo;
        Projectiles _projectileProperties;
        currentProjectile = changeTo;
        _projectileProperties = projectile[changeTo].gameObject.GetComponent<Projectiles>();
        ProjectileChange(changeTo, _projectileProperties);




    }

    //allows you to shoot again
    IEnumerator allowProjectile()
    {
        yield return new WaitForSeconds(timeBetweenShoots);
        alloowshoot = true;
    }

    //changes your projectile
    void ProjectileChange(int changeToWhat, Projectiles _project)
    {

        ammoCost = _project.ammoCost;
        timeBetweenShoots = _project.betweenShoots;
    }

    //reloads
    IEnumerator Reload(float reloadTime, int reloadAmount)
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmo += reloadAmount;
        currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);


    }
}
