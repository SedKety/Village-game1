using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNodeScript : MonoBehaviour
{
    public int nodeHealth;
    [SerializeField] private GameObject itemToDrop; 
    public nodeType typeOfResourceNode;
    public enum nodeType
    {
        rock,
        tree,
        food,
    }

    public void OnDmg(int dmgTaken)
    {
        nodeHealth -= dmgTaken;

        if (nodeHealth <= 0)
        {
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(typeOfResourceNode == nodeType.rock && dmgTaken >= 5)
        {
                transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        }
    }

}
