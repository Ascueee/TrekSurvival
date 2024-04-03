using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherAndHold : MonoBehaviour
{
    [Header("GatherAndHold Var")]
    [SerializeField] int currentRound;
    [SerializeField] int maxRound;
    [SerializeField] int maxPoints;
    [SerializeField] int currentPlayerPoints;
    [SerializeField] GameObject[] pickUpObjects;
    [SerializeField] Transform[] objectSpawnLocations;
    [SerializeField] bool objectiveComplete;
    bool canSpawnObject;
    bool objectCollected;

    bool holdingObject;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerPoints = 0;

        canSpawnObject = true;
        objectCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(objectiveComplete == false && currentRound < maxRound)
        {
            Objective();
        }
        else if(objectiveComplete == true)
        {
          
        }
        
    }

    public virtual void Objective()
    {
        if(currentPlayerPoints >= maxPoints)
        {
            currentRound++;
            currentPlayerPoints = 0;
            canSpawnObject = true;
            holdingObject = false;
        }

        if(currentRound >= maxRound)
        {
            objectiveComplete = true;
        }
    }

    void SpawnObject()
    {
        if (canSpawnObject)
        {
            int randObjectIndex = Random.Range(0, pickUpObjects.Length);
            int randSpawnLocations = Random.Range(0, objectSpawnLocations.Length);
            var gameObject = Instantiate(pickUpObjects[randObjectIndex], objectSpawnLocations[randSpawnLocations].position, Quaternion.identity);
            canSpawnObject = false;
        }
    }

    void inObjective()
    {
        if(holdingObject == true)
        {
            currentPlayerPoints++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(canSpawnObject == true && holdingObject == false)
            {
                SpawnObject();
            }
            else if(canSpawnObject ==  false && holdingObject == true)
            {
                inObjective();
            }
            
        }
    }

    public void SetCanHold(bool isHolding)
    {
        holdingObject = isHolding;
    }

    public bool GetObjectiveComplete()
    {
        return objectiveComplete;
    }
}
