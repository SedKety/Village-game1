using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyScript : MonoBehaviour, IDamagable
{
    public int enemyDmg;
    public int enemyHp;

    public NavMeshAgent navMeshAgent;

    public GameObject[] itemToDrop;
    public Transform itemspawnpoint;

    public LayerMask layerToWalkOn;

    public bool shouldLookAtPlayer;
    public void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        shouldLookAtPlayer = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerManager>().DoDamage(enemyDmg);
        }
    }

    public virtual void Damagable(int dmg, GameObject weaponUsed)
    {
        enemyHp -= dmg;
        if (enemyHp <= 0)
        {
            Instantiate(itemToDrop[0], itemspawnpoint.position, Quaternion.identity);
            int spawnBrain = Random.Range(0, 2);

            if(spawnBrain == 0 && itemToDrop[1])
            {
                Instantiate(itemToDrop[1], itemspawnpoint.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    public IEnumerator despawnTimer()
    {
        yield return new WaitForSeconds(100);
        Destroy(gameObject);
    }
}