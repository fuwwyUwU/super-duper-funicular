using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shooting : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI ammoScreenn;
    Rigidbody2D _rb;
    [SerializeField] GameObject[] projectile;
    public int currentProjectile = 1;
    [SerializeField] float ammoCost;
    List<GameObject> shootAt;
    [SerializeField] float currentAmmo = 0;
    [SerializeField] float maxAmmo = 100;
    [SerializeField] float timeBetweenShoots = 1;
    float timeToReload = 0;
    [SerializeField] bool alloowshoot;
    Movement _playerMovement;
    bool shooting = false;
    // Start is called before the first frame update
    void Start()
    {
        //allows you to shoot
        alloowshoot = true;
        //creats a list of positions where do projectiles will be instansiated
        shootAt = new List<GameObject>();

            //adds all the locations it can be instansiated at


        foreach (Transform transform in gameObject.transform)
        {
            if (transform.CompareTag("Projectile Spawnpoint"))
            {
                shootAt.Add(transform.gameObject);
            }

        }    
        
        
        //fills up the ammo
            currentAmmo = maxAmmo;

            //changes the projectile
            ChangeProjectile(1);
        


        //fills up the ammo
        currentAmmo = maxAmmo;

        //changes the projectile
        ChangeProjectile(1);
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<Movement>();
        _playerMovement.controls.Player.Shoot.performed += ctx => ShootingInputHandler(ctx.ReadValue<float>());  
        _playerMovement.controls.Player.Reload.performed += ctx => Reload(); 
    }

    void ShootingInputHandler(float pressed)
    {
        Debug.Log(pressed);

        if (pressed != 0)
        {
            shooting = true;    

        }
        else
        {
            shooting = false;
        }

    }

    
    void Reload()
    {
        //reload    
        StartCoroutine(Reload(timeToReload, maxAmmo));
        ChangeProjectile(currentProjectile);
    }
    
    // Update is called once per frame
    void Update()
    {
        


        //if you are pressing shooting, shoot
        if (!alloowshoot) return;
        else if (shooting && currentAmmo >= ammoCost) //checks if you have enougth ammo to shoot
                {

                    for (int i = 0; i < shootAt.Count; i++) 
                    {
                        //shoots a projectile att every projectile spawnpoint
                        shoot(shootAt[i].transform.position, shootAt[i].transform.rotation);
                        StartCoroutine(allowProjectile());
                        alloowshoot = false;
                    }
                    //remvoes the ammo you spend
                    currentAmmo -= ammoCost;
                }


        //updates the ammo counter
        ammoScreenn.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }

    void shoot(Vector2 where, Quaternion rotation)
    {
        //instaniates the projectile
        Instantiate(projectile[currentProjectile], where, rotation);
    }

    //changes your projectile
    public void ChangeProjectile(int changeTo)
    {
        currentProjectile = changeTo;
        Projectiles _projectileProperties = projectile[changeTo].gameObject.GetComponent<Projectiles>(); ;

        currentProjectile = changeTo;

        
        ProjectileChange(changeTo, _projectileProperties);
    }

    //allows you to shoot again
    IEnumerator allowProjectile()
    {
        Debug.Log("ran");
        yield return new WaitForSeconds(timeBetweenShoots);
        alloowshoot = true;
    }

    //changes your projectile
    void ProjectileChange(int changeToWhat, Projectiles _project)
    {

        ammoCost = _project.ammoCost;
        timeBetweenShoots = _project.betweenShoots;
        Debug.Log(ammoCost);
    }

    //reloads
    IEnumerator Reload(float reloadTime, float reloadAmount)
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmo += reloadAmount;
        currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);


    }
}
