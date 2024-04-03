using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    [Header("Enemy Components")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform playerObj;

    [Header("Enemy Movement Stats")]
    [SerializeField] float rotationSpeed;
    [SerializeField] float enemySpeed;



    private void Start()
    {
        agent.speed = enemySpeed;
    }
    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        
    }

    //Navigates and rotates the enemy to the player position
    void MoveToPlayer()
    {
        var playerGameObject = GameObject.FindWithTag("Player");
        playerObj.position = playerGameObject.transform.position;

        Vector3 movePosition = playerObj.position;
        agent.destination = playerObj.position;

        //rotate towards player


        //gets the direction the enemy should be looking at
        Vector3 lookDirection = playerObj.position - transform.position;
        lookDirection.y = 0;
        
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }
}
