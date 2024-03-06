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

    public LayerMask layerToWalkOn;
    public void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 10, layerToWalkOn))
        {
            print(3456789);
           transform.rotation.SetLookRotation(transform.forward,  hit.normal);
            //transform.LookAt(hit.transform);
        }
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
