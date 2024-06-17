using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    
    public GameObject turret;
    public GameObject bullet;
    public Transform firePoint;
    Bullets bulletsDisplay;

    public float fireRate = 1f;
    private float nextFire = 0f;

    public int bulletCount;

    // Start is called before the first frame update
    void Start()
    {
        bulletsDisplay = GameObject.Find("BulletDisplay").GetComponent<Bullets>();
        bulletsDisplay.AddBullets(bulletCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletCount > 0)
        {
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + 1f / fireRate;
                Fire();
                bulletsDisplay.AddBullets(-1);
            }
        }
    }

    void Fire()
    {
        GameObject bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 1500);
        Destroy(bulletInstance, 2f);
        bulletCount--;
    }
}
