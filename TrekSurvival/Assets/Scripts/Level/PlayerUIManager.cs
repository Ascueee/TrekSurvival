using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    [Header("Player UI Manager Vars")]
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] CanvasGroup playerUI;
    [SerializeField] GameObject currentWeapon;
    [SerializeField] GameObject player;
    [SerializeField] int playerHealth;
    [SerializeField] float fadeInTime;
    bool fadeIn;
    bool fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        fadeOut = false;
        fadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        FadeIn();

        if(player.GetComponent<Player>().GetPlayerHeal() <= 0)
        {
            fadeOut = true;
        }

        if(fadeOut == true)
        {
            FadeOut();
        }

        UpdateAmmoText();
        UpdateHealthText();
    }

    void UpdateAmmoText()
    {
        var currentWeapon = GameObject.FindWithTag("Weapon");
        ammoText.text = currentWeapon.GetComponent<Weapon>().GetAmmoCount() + " / " + currentWeapon.GetComponent<Weapon>().GetMagazineSize();
    }

    void UpdateHealthText()
    {
        healthText.text = player.GetComponent<Player>().GetPlayerHeal() + " / " + player.GetComponent<Player>().GetMaxHealth();
    }

    void FadeIn()
    {
        LeanTween.init(200);

        if (fadeIn == true)
        {
            LeanTween.value(ammoText.gameObject, ammoText.color.a, 1f, fadeInTime).setOnUpdate(ChangeAmmoTextAlpha);
            LeanTween.value(healthText.gameObject, healthText.color.a, 1f, fadeInTime).setOnUpdate(ChangeHealthTextAlpha);

            fadeIn = false;
        }
    }

    void FadeOut()
    {
        LeanTween.value(ammoText.gameObject, ammoText.color.a, 0f, 0.5f).setOnUpdate(ChangeAmmoTextAlpha);
        LeanTween.value(healthText.gameObject, healthText.color.a, 0f, 0.5f).setOnUpdate(ChangeHealthTextAlpha);
    }

    void ChangeAmmoTextAlpha(float a)
    {
        var alphaChange = new Vector4(ammoText.color.r, ammoText.color.g, ammoText.color.b, a);

        ammoText.color = alphaChange;
    }

    void ChangeHealthTextAlpha(float a)
    {
        var alphaChange = new Vector4(healthText.color.r, healthText.color.g, healthText.color.b, a);

        healthText.color = alphaChange;
    }
}
