using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongPoint : MonoBehaviour
{
    [Header("StrondPoint Vars")]
    [SerializeField] float timeToStayInRadius;
    [SerializeField] bool isInRadius;
    float countDown;
    bool objectiveComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        isInRadius = false;
        objectiveComplete = false;
        countDown = timeToStayInRadius;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectiveMechanic();

    }

    void ObjectiveMechanic()
    {
        if(isInRadius == true)
        {
            countDown -= Time.deltaTime;

            if (countDown <= 0)
            {
                print("Complete");
                objectiveComplete = true;
                isInRadius = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isInRadius = true;
        }
    }

    public bool GetObjectiveComplete()
    {
        return objectiveComplete;
    }
}
