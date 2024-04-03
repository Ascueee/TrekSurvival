using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            var currentWeapon = GameObject.FindWithTag("Weapon");
            other.gameObject.GetComponent<Enemy>().SetEnemyHealth(-currentWeapon.GetComponent<Weapon>().GetBulletDamage());
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Turret")
        {
            var currentWeapon = GameObject.FindWithTag("Weapon");
            other.gameObject.GetComponent<DestroyTheTurret>().SetTurretHealth(currentWeapon.GetComponent<Weapon>().GetBulletDamage());
            Destroy(gameObject);
        }
    }
}
