using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] Enemy baseEnemyScript;
    [SerializeField] GameObject obj;
    int dmg;
    private void OnTriggerEnter(Collider other)
    {
        obj = GameObject.FindWithTag("Enemy");
        baseEnemyScript = obj.GetComponent<Enemy>();
        dmg = baseEnemyScript.GetDmg();


        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().SetPlayerHealth(dmg);
        }
    }
}
