using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Variables")]
    [SerializeField] int health;
    [SerializeField] int dmg;
    [SerializeField] float speed;
    [SerializeField] float attackTime;
    [SerializeField] float canAttackDistance;
    bool canAttack;
    bool inCoolDown;

    [Header("Enemy Components")]
    [SerializeField] GameObject attackObj;
    [SerializeField] Transform attacKPos;
    [SerializeField] GameObject playerObj;
    [SerializeField] GameObject currentObj;
    [SerializeField] GameObject deathParticleEffect;

    

    // Start is called before the first frame update
    void Start()
    {
        inCoolDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        CanAttack();
        Attack();
    }

    void Death()
    {
        if(health <= 0)
        {
            GameObject[] objectives = GameObject.FindGameObjectsWithTag("Objective");

            for(int i = 0; i < objectives.Length; i++)
            {
                if (objectives[i].name == "HordeSurvival")
                {
                    var particleEffect = Instantiate(deathParticleEffect, transform.position, Quaternion.identity);
                    objectives[i].GetComponent<HordeSurvival>().DecrementZombiesInScenes(1);
                    Destroy(particleEffect, 0.6f);
                    Destroy(gameObject);
                }
                else
                {
                    print("is the particle spawning?");
                    var particleEffect = Instantiate(deathParticleEffect, transform.position, Quaternion.identity);
                    Destroy(particleEffect, 0.6f);
                    Destroy(gameObject);
                }
            }
        }
    }


    void CanAttack()
    {
        playerObj = GameObject.FindWithTag("Player");
        var distanceFromPlayer = transform.position - playerObj.transform.position;

        if (distanceFromPlayer.magnitude <= canAttackDistance && inCoolDown == false)
        {
            canAttack = true;
        }
    }

    void Attack()
    {
        if (canAttack)
        {
            var attack = Instantiate(attackObj, attacKPos.position, transform.rotation, gameObject.transform);
            canAttack = false;
            Destroy(attack, attackTime);
            canAttack = false;
            inCoolDown = true;
            Invoke("ResetCoolDown", attackTime);
        }

    }

    void ResetCoolDown()
    {
        inCoolDown = false;
    }
    public int GetEnemyHealth()
    {
        return health;
    }

    public void SetEnemyHealth(int newHealth)
    {
        health += newHealth;

    }

    public int GetDmg()
    {
        return dmg;
    }
}
