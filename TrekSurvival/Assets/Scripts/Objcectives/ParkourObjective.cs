using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourObjective : MonoBehaviour
{
    bool objectiveComplete;
    bool hitTrigger;

    // Start is called before the first frame update
    void Start()
    {
        objectiveComplete = false;
    }

    private void Update()
    {
        if(hitTrigger == true)
        {
            objectiveComplete = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            hitTrigger = true;
        }
    }


    public bool GetObjectiveComplete()
    {
        return objectiveComplete;
    }
}
