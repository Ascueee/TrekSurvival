using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
    [Header("Weapon Drop Vars")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject currentWeapon;
    [SerializeField] GameObject[] weaponsToPick;
    [SerializeField] GameObject weaponsHolder, weaponPlacement;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioClip pickUp;
    [SerializeField] float animationSpeed;
    float elapsedTime;
    bool pickedUp;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentWeapon();
        SwitchWeapon();
    }

    void SwitchWeapon()
    {
        if (pickedUp == true)
        {
            Destroy(currentWeapon);
            audioSrc.clip = pickUp;
            audioSrc.Play();
            int randWeapon = Random.Range(0, weaponsToPick.Length);
            currentWeapon = Instantiate(weaponsToPick[randWeapon], weaponPlacement.transform.position, weaponPlacement.transform.rotation,weaponsHolder.transform);
            pickedUp = false;
            Destroy(gameObject,1);
            
        }
    }


    void GetCurrentWeapon()
    {
        currentWeapon = GameObject.FindWithTag("Weapon");
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickedUp = true;
        }
    }
}
