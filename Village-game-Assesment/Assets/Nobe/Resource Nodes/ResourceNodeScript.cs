using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceNodeScript : MonoBehaviour, IDamagable
{
    public int nodeHealth;
    [SerializeField]  GameObject itemToDrop;

    [SerializeField] Transform itemspawnpoint;

    public GameObject enemyObject;
    public bool destroyParent;

    public void Damagable(int dmg, GameObject weaponUsed)
    {
        nodeHealth -= dmg;
        if (transform.localScale != new Vector3(0.25f, 0.25f, 0.25f))
        {
            transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        }
        if (nodeHealth <= 0)
        {
            Instantiate(itemToDrop, itemspawnpoint.position, Quaternion.identity);
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<AudioSource>().Play();
            int spawnEnemyOrNot = Random.Range(0, 2);
            if (spawnEnemyOrNot == 0 && enemyObject)
            {
                Instantiate(enemyObject, itemspawnpoint.position, Quaternion.identity);
            }
            if (destroyParent)
            {
                Destroy(gameObject.transform.parent);
            }
            else
            {
                Destroy(gameObject, 2f);
            }
        }
    }
}
