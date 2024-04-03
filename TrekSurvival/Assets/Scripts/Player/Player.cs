using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    [SerializeField] int playerHealth;
    [SerializeField] Volume volume;
    [SerializeField] Vignette vignette;
    [SerializeField] GameObject weaponHolder, weaponPlacement;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioClip playerHurt, playerDead;

    int maxHealth;
    
    
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet(out vignette);
        maxHealth = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        DamageEffect();
    }

    void DamageEffect()
    {
        if(playerHealth <= 15 && playerHealth > 10)
        {
            vignette.intensity.value = 0.388f;
        }
        else if(playerHealth <= 10 && playerHealth > 5)
        {
            vignette.intensity.value = 0.549f;
        }
        else if(playerHealth <= 5)
        {
            vignette.intensity.value = 0.76f;
        }
        else
        {
            vignette.intensity.value = 0.168f;
        }
    }

    void Death()
    {
        if (playerHealth <= 0)
        {
            audioSrc.clip = playerDead;
            audioSrc.Play();
            Destroy(gameObject,2);
        }
    }

    public int GetPlayerHeal()
    {
        return playerHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetPlayerHealth(int healthChange)
    {
        if(healthChange < 0)
        {
            audioSrc.clip = playerHurt;
            audioSrc.Play();
        }

        playerHealth += healthChange;
    }

    public GameObject GetWeaponHolder()
    {
        return weaponHolder;
    }

    public GameObject GetWeaponPlacement()
    {
        return weaponPlacement;
    }

    
}
