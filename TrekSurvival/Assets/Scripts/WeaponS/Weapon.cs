using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] int damage;
    [SerializeField] float timeBetweenShooting, spread, bulletSpeed, range, reloadTime, timeBetweenShots;
    [SerializeField] int magazineSize, bulletPerTap;
    [SerializeField] bool allowButtonHold;
    [SerializeField] int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    [Header("Weapon Components")]
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioClip shootClip, reloadClip;

    [Header("Recoil On Gun")]
    [SerializeField] Transform startPos, endPos;
    [SerializeField] float durationOfRecoil;
    bool lerpOne, lerpTwo, canLerp;
    float elaspedTime;
    private void Start()
    {
        canLerp = false;
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();
    }

    void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }

        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletPerTap;
            Shoot();
            lerpOne = true;
        }
    }

    void Shoot()
    {
        readyToShoot = false;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //calculate Direction with Spread
        Vector3 direction = muzzle.transform.forward + new Vector3 (x, y, 0);


        var bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
        Destroy(bullet, range);
        canLerp = true;



        bulletsLeft--;
        bulletsShot--;

        audioSrc.clip = shootClip;
        audioSrc.Play();

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 &&  bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
        
        
    }

    void ResetShot()
    {
        readyToShoot = true;
    }

    void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished()
    {
        audioSrc.clip = reloadClip;
        audioSrc.Play();
        bulletsLeft = magazineSize;
        reloading = false;
    }


    ///GETTER METHODS
    public int GetBulletDamage()
    {
        return damage;
    }

    public int GetAmmoCount()
    {
        return bulletsLeft;
    }

    public int GetMagazineSize()
    {
        return magazineSize;
    }
}
