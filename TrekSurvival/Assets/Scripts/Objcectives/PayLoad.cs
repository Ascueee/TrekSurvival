using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayLoad : MonoBehaviour
{
    [SerializeField] Transform payLoadObj;
    [SerializeField] Transform[] wayPointList;
    [SerializeField] float elapsedTime;
    [SerializeField] float lerpDuration;
    [SerializeField] bool playerInRadius;
    [SerializeField] bool objectiveComplete = false;

    // Update is called once per frame
    void Update()
    {
        InterpolateObject();
    }

    void InterpolateObject()
    {
        if(playerInRadius == true)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / lerpDuration;

            payLoadObj.position = Vector3.Lerp(wayPointList[0].position, wayPointList[1].position, percentageComplete);

            if(payLoadObj.position == wayPointList[1].position)
            {
                print("The payload objective is complete");
                objectiveComplete = true;
            }
        }
    }


    public void SetPlayerRadius(bool setVal)
    {
        playerInRadius = setVal;
    }


    public bool GetObjectiveComplete()
    {
        return objectiveComplete;
    }

}
