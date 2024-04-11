using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregScript : EnemyScript
{
    public int lifeStage;
    public GameObject player;
    public GameObject bossGreg;
    public bool hasSpawned;
    public override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            transform.up = hit.normal;
            if (shouldLookAtPlayer & navMeshAgent.destination != null & lifeStage != 0)
            {
                transform.LookAt(navMeshAgent.destination);
            }
            else
            {
                transform.LookAt(player.transform);
            }
        }
        if (navMeshAgent.destination == null)
        {
            navMeshAgent.destination = transform.position;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyChecker"))
        {
            navMeshAgent.destination = other.transform.position;
            shouldLookAtPlayer = true;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyChecker"))
        {
            shouldLookAtPlayer = false;
        }
    }

    public override void Damagable(int dmg, GameObject weaponUsed)
    {
        enemyHp -= dmg;
        if (enemyHp <= 0)
        {
            Instantiate(itemToDrop[0], itemspawnpoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Stick"))
        {
            OnLifeStageIncrease();
            Destroy(collision.collider.gameObject);
        }
    }

    public void OnLifeStageIncrease()
    {
        if (lifeStage != 2)
        {
            enemyHp = maxEnemyHp;
            enemyHp *= 2;
            gameObject.transform.localScale *= 1.25f;
            lifeStage += 1;
        }
        else
        {
            if (hasSpawned == false)
            {
                Instantiate(bossGreg, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            hasSpawned = true;
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDamagable>() != null)
        {
            collision.gameObject.GetComponent<IDamagable>().Damagable(enemyDmg, gameObject);
        }
    }
}
