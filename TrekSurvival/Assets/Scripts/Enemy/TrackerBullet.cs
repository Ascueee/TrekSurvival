using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerBullet : MonoBehaviour
{
    [SerializeField] Transform playerObj;
    [SerializeField] Rigidbody rb;
    [SerializeField] int dmg;
    [SerializeField] float projectileSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject particleEffect;

    // Update is called once per frame
    void Update()
    {
        LookToPlayer();
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {

        var playerDirection =  playerObj.position - transform.position;
        playerDirection = playerDirection.normalized;

        rb.AddForce(playerDirection * projectileSpeed, ForceMode.Force);

        Destroy(gameObject, 7);

    }

    void LookToPlayer()
    {
        //rotate towards player
        //gets the direction the enemy should be looking at
        Vector3 lookDirection = playerObj.position - transform.position;
        lookDirection.y = 0;

        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().SetPlayerHealth(dmg);
            var particleObj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(particleObj, 2);
            Destroy(gameObject, 0.1f);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            var particleObj = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(particleObj, 2);
            Destroy(gameObject, 0.1f);

        }
        
    }
}
