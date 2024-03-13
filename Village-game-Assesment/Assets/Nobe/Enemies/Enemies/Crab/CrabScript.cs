using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabScript : EnemyScript
{
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

    public override void Damagable(int dmg, GameObject weaponUsed)
    {
        enemyHp -= dmg;
        if (enemyHp <= 0)
        {
            if (weaponUsed.GetComponent<Firebal>() != null)
            {
                Instantiate(itemToDrop[2], itemspawnpoint.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
