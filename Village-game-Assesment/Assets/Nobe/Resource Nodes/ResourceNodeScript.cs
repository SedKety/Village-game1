using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceNodeScript : MonoBehaviour
{
    public int nodeHealth;
    [SerializeField]  GameObject itemToDrop;

    [SerializeField] Transform itemspawnpoint;

    public void OnDmg(int dmgTaken)
    {
        nodeHealth -= dmgTaken;
        if(transform.localScale != new Vector3(0.25f, 0.25f, 0.25f))
        {
            transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        }
        if (nodeHealth <= 0)
        {
            Instantiate(itemToDrop, itemspawnpoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
