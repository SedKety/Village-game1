using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSpawnZoneScript : MonoBehaviour
{
    public GameObject filteredOutGameObject;

    public void Start()
    {
        Destroy(gameObject, 3);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == (filteredOutGameObject.name + "Clone"))
        {
            Destroy(other.gameObject);
        }
    }
}
