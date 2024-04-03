using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeSurvival : MonoBehaviour
{
    [Header("GameMode Stats")]
    [SerializeField] float survivalTime;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] int zombiesPerHorde;
    [SerializeField] int currentZombiesInScene;
    [SerializeField] bool infiniteSpawn;
    [SerializeField] bool objectiveCompleted;

    [Header("Spawner Arrays")]
    [SerializeField] Transform[] zombieSpawnLocations;
    [SerializeField] GameObject[] zombieTypes;


    float timerCountdown;
    bool canSpawn;



    // Start is called before the first frame update
    void Start()
    {
        timerCountdown = survivalTime;
        objectiveCompleted = false;
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (infiniteSpawn == true)
        {
            Spawn();
            
        }
        else if (infiniteSpawn == false)
        {
            Objective();

            if (objectiveCompleted == false)
            {
                Spawn();
            }

        }
    }

    public void Objective()
    {
        if(objectiveCompleted == false && timerCountdown >= 0)
        {
            timerCountdown -= Time.deltaTime;

            if (timerCountdown <= 0) 
            {
                objectiveCompleted = true;
            }
        }
    }

    void Spawn()
    {
        if(currentZombiesInScene < zombiesPerHorde && canSpawn == true)
        {
            
            Invoke("SpawnZombies", timeBetweenSpawn);
            canSpawn = false;
        }
        
    }


    //Spawns the zombies into the scene
    void SpawnZombies()
    {
        //Gives a randon int to randomly spawn a type of zombie and location
        int randEnemyIndex = Random.Range(0, zombieTypes.Length);
        int randSpawnIndex = Random.Range(0, zombieSpawnLocations.Length);
        var enemyInGame = Instantiate(zombieTypes[randEnemyIndex], zombieSpawnLocations[randSpawnIndex].position, Quaternion.identity);

        currentZombiesInScene++;
        Invoke("ResetCanSpawn", timeBetweenSpawn);

    }

    //resets canSpawn var
    void ResetCanSpawn()
    {
        canSpawn = true;
    }

    //GETTER AND SETTER METHODS
    public void DecrementZombiesInScenes(int decrement)
    {
        currentZombiesInScene -= decrement;
    }

    public bool GetObjectiveCompleted()
    {
        return objectiveCompleted;
    }

    public void IncreaseZombiesPerHorde(int increment)
    {
        zombiesPerHorde += increment;
    }

}
