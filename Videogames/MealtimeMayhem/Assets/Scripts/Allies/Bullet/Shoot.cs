using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform point;
    float fireRate;
    float nextFire;


    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
         if (Time.time >= nextFire)
        {
            shoot();
            nextFire = Time.time + 1f / fireRate;
        }
    }

    private void shoot()
    {
        GameObject bullets = Instantiate(bullet, point.position, point.rotation);
        // Configure bullet properties if needed
    }
}
