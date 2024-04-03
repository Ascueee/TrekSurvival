using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    [Header("Health Drop")]
    [SerializeField] GameObject playerObj;
    [SerializeField] int amountOfHealthGiven;
    [SerializeField] float destroyTime;
    [SerializeField] AudioSource audioSrs;
    [SerializeField] AudioClip pickUpSound;
    bool pickedUp;
    // Update is called once per frame
    void Update()
    {
        PickUp();
    }

    void PickUp()
    {
        if(pickedUp == true)
        {
            if((playerObj.GetComponent<Player>().GetPlayerHeal() + amountOfHealthGiven) < playerObj.GetComponent<Player>().GetMaxHealth())
            {
                audioSrs.clip = pickUpSound;
                audioSrs.Play();
                playerObj.GetComponent<Player>().SetPlayerHealth(amountOfHealthGiven);
                Destroy(gameObject,1);
                pickedUp = false;
            }
            else
            {
                audioSrs.clip = pickUpSound;
                audioSrs.Play();
                var healthToGive = playerObj.GetComponent<Player>().GetMaxHealth() - playerObj.GetComponent<Player>().GetPlayerHeal(); 
                playerObj.GetComponent<Player>().SetPlayerHealth(healthToGive);
                Destroy(gameObject, 1);
                pickedUp = false;
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickedUp = true;
        }
    }
}
