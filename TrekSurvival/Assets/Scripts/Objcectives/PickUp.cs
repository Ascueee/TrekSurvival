using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameObject[] objectives;
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            objectives = GameObject.FindGameObjectsWithTag("Objective");

            for(int i = 0; i < objectives.Length; i++)
            {
                if (objectives[i].name == "GatherAndHold(Clone)" || objectives[i].name == "GatherAndHold")
                {
                    print("Hit the pickup");
                    objectives[i].GetComponent<GatherAndHold>().SetCanHold(true);
                    Destroy(gameObject);
                }
            }
        }
    }
}
