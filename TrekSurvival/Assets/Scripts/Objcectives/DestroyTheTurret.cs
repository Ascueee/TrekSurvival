using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTheTurret : MonoBehaviour
{
    [Header("Destoy The Turret Vars")]
    [SerializeField] int turretHealth;
    [SerializeField] GameObject turretBullet;
    [SerializeField] float turretCoolDown;
    [SerializeField] GameObject playerObj;
    [SerializeField] GameObject[] muzzles;
    [SerializeField] GameObject particleEffect;
    bool objectiveComplete = false;
    bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();
        TurretDeath();
    }


    void ShootBullet()
    {
        if(canShoot == true)
        {
            foreach (var item in muzzles)
            {
                var bullet = Instantiate(turretBullet, item.transform.position, Quaternion.identity);
                bullet.GetComponent<TurretBullet>().SetDirection(item.transform.forward);
            }

            canShoot = false;
            Invoke("ResetShoot", turretCoolDown);
        }
    }

    void TurretDeath()
    {
        if(turretHealth <= 0)
        {
            var particleObj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(particleObj, 2);
            objectiveComplete = true;
        }
    }

    void ResetShoot()
    {
        canShoot = true;
    }

    public void SetTurretHealth(int dmg)
    {
        turretHealth -= dmg;
    }

    public bool GetObjectiveComplete()
    {
        return objectiveComplete;
    }
}
