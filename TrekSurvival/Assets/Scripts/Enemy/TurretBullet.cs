using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [Header("Bullet Vars")]
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject particleEffect;
    [SerializeField] float bulletLifeTime;
    [SerializeField] float bulletSpeed;
    [SerializeField] int bulletDmg;
    [SerializeField] Vector3 directionToShoot;


    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        rb.AddForce(directionToShoot * bulletSpeed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().SetPlayerHealth(bulletDmg);
            var particleObj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(particleObj, 2);
            Destroy(gameObject, 0.1f);
        }
        else
        {
            var particleObj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(particleObj, 2);
            Destroy(gameObject, 0.1f);
        }
    }

    public void SetDirection(Vector3 newDirection)
    {
        directionToShoot = newDirection;
    }
}
