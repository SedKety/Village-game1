using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public int enemyDmg;
    public int enemyHp;

    public NavMeshAgent navMeshAgent;

    public GameObject itemToDrop;
    public Transform itemspawnpoint;

    public void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyChecker"))
        {
            navMeshAgent.destination = (other.transform.position);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerManager>().DoDamage(enemyDmg);
        }
    }

    public void OnDmg(int dmgTaken)
    {
        enemyHp -= dmgTaken;
        if (enemyHp <= 0)
        {
            Instantiate(itemToDrop, itemspawnpoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}