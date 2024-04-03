using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level Manager")]
    [SerializeField] GameObject[] barrierObjects;
    [SerializeField] GameObject[] ObjectivesInLevel;
    [SerializeField] GameObject[] disableObjects;
    [SerializeField] int currentSection;
    [SerializeField] int amountOfObjectives;
    [SerializeField] bool levelComplete;

    void Start()
    {
        currentSection = 0;
        levelComplete = false;

    }
    // Update is called once per frame
    void Update()
    {
        LevelProgession();
    }


    //This method progresses through the different objectives if they are complete
    void LevelProgession()
    {
        //Checks if the level is complete
        if(levelComplete == false)
        {
            //checks what section the player is on with the barrier ID
            if (currentSection == barrierObjects[currentSection].GetComponent<Barrier>().GetBarrierId())
            {
                //sets the objective to the current Objective
                var Objective = ObjectivesInLevel[currentSection];
                Objective.SetActive(true);

                if(Objective.name == "HordeSurvival")
                {
                    //checks if the the objective is complete
                    if (Objective.GetComponent<HordeSurvival>().GetObjectiveCompleted() == true)
                    {
                        //destroys the barrier
                        Objective.SetActive(false);
                        Destroy(barrierObjects[currentSection]);
                        currentSection++;//increments the section

                    }
                }
                else if(Objective.name == "ParkourObject")
                {
                    
                    if (Objective.GetComponent<ParkourObjective>().GetObjectiveComplete() == true)
                    {
                        Objective.SetActive(false);
                        Destroy(barrierObjects[currentSection]);
                        disableObjects[0].SetActive(false);
                        disableObjects[1].SetActive(false);
                        currentSection++;
                    }
                }
                else if (Objective.name == "GatherAndHold")
                {
                    if (Objective.GetComponent<GatherAndHold>().GetObjectiveComplete() == true)
                    {
                        Destroy(barrierObjects[currentSection]);
                        Objective.SetActive(false);
                        currentSection++;

                    }
                }
            }

            if (currentSection >= amountOfObjectives)
            {
                levelComplete = true;
            }
        }
    }
}
