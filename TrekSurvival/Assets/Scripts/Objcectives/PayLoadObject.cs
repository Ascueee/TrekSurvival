using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayLoadObject : MonoBehaviour
{
    [SerializeField] PayLoad pl;
    [SerializeField] bool inRadius = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRadius = true;
            pl.SetPlayerRadius(inRadius);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRadius = false;
            pl.SetPlayerRadius(inRadius);
        }
    }
}
