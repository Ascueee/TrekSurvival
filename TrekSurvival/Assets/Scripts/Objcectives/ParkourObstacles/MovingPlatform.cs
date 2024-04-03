using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform startPos, endPos;
    [SerializeField] bool isLooping;
    [SerializeField] float durationOfLerp;
    [SerializeField] float elapsedTime;
    [SerializeField] float lerpCoolDown;
    bool inCoolDown;
    int track;


    // Start is called before the first frame update
    void Start()
    {
        inCoolDown = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isLooping == false)
        {
            SingleLerp(startPos, endPos);
        }
        else
        {
            LoopLerp();
        }

    }

    //Linearly Interpolates the platform between a start and end point once
    void SingleLerp(Transform startPos, Transform endPos)
    {
        if(inCoolDown == false)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / durationOfLerp;

            if(percentageComplete < 1)
            {
                transform.position = Vector3.Lerp(startPos.position, endPos.position, percentageComplete);
            }
            else if (percentageComplete >= 1)
            {
                inCoolDown = true;
                elapsedTime = 0;
                track++;
                Invoke("ResetCoolDown", lerpCoolDown);

            }
        }

    }

    //Linearly Interpolates the platform between two points
    void LoopLerp()
    {
        if(inCoolDown == false)
        {
            if (track % 2 != 0)
            {
                SingleLerp(endPos, startPos);
            }
            else if(track % 2 == 0)
            {
                SingleLerp(startPos, endPos);
            }
        }

    }

    //Resets the cooldown for lerp
    void ResetCoolDown()
    {
        inCoolDown = false;
    }
}
