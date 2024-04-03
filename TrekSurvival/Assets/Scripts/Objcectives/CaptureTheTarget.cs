using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureTheTarget : MonoBehaviour
{
    [Header("Capture The Target Vals")]
    [SerializeField] float targetSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float pickDirectionTimer;
    [SerializeField] Rigidbody rb;
    [SerializeField] float coolDown;
    [SerializeField] Vector3 directionToGo;
    bool collected;
    bool objectiveComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        collected = false;
        coolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PickDirectionToRun();
        Movement(directionToGo);
        TargetCollected();
    }

    void PickDirectionToRun()
    {
        coolDown -= Time.deltaTime;

        if(coolDown <= 0)
        {
            int randDirection = Random.Range(0, 3);
            coolDown = pickDirectionTimer;

            if(randDirection == 0)
            {
                directionToGo = Vector3.forward;
            }
            else if(randDirection == 1)
            {
                directionToGo = Vector3.right;
            }
            else if(randDirection == 2)
            {
                directionToGo = Vector3.left;
            }
            else if(randDirection == 3)
            {
                directionToGo = Vector3.back;
            }
        }

    }

    void TargetCollected()
    {
        if(collected == true)
        {
            objectiveComplete = true;
        }
    }

    //moves the target in a given direction
    void Movement(Vector3 direction)
    {
        if(Mathf.Abs(rb.velocity.magnitude) >= maxSpeed)
        {

            return;
        }
        else
        {
            rb.AddForce(direction * targetSpeed, ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collected = true;
        }
    }

    public bool GetObjectiveComplete()
    {
        return objectiveComplete;
    }
}
