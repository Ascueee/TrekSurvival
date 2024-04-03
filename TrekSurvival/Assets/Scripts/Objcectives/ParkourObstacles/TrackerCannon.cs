using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerCannon : MonoBehaviour
{
    [Header("TrackerCannon Attributes")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float spawnTimer;
    [SerializeField] bool canShoot;
    [SerializeField] GameObject particleEffect;
    float timerCountDown;
    // Start is called before the first frame update
    void Start()
    {
        timerCountDown = spawnTimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        Shoot();

    }

    void Shoot()
    {
        if(canShoot == true)
        {
            var particleObject = Instantiate(particleEffect, bulletSpawn.position, Quaternion.identity);
            var gameObject = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            Destroy(particleObject, 2);
            timerCountDown = spawnTimer;
            canShoot = false;
        }
    }

    void Timer()
    {
        timerCountDown -= Time.deltaTime;

        if (timerCountDown <= 0)
        {
            canShoot = true;
        }
    }
}
