using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour, IDamagable
{
    public int enemyDmg;
    public int enemyHp;

    public NavMeshAgent navMeshAgent;

    public GameObject itemToDrop;
    public Transform itemspawnpoint;

    public LayerMask layerToWalkOn;

    public bool shouldLookAtPlayer;
    public void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        shouldLookAtPlayer = false;
    }
    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            transform.up = hit.normal;
            if (shouldLookAtPlayer & navMeshAgent.destination != null)
            {
                transform.LookAt(navMeshAgent.destination);
            }

        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyChecker"))
        {
            navMeshAgent.destination = (other.transform.position);
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


    public IEnumerator despawnTimer()
    {
        yield return new WaitForSeconds(100);
        Destroy(gameObject);
    }

    public void Damagable(int dmg)
    {
        OnDmg(dmg);
    }
}