using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSpawnZoneScript : MonoBehaviour
{
    public GameObject filteredOutGameObject;

    public void Start()
    {
        Destroy(gameObject, 0.5f);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == (filteredOutGameObject.name + "Clone"))
        {
            Destroy(collision.gameObject);
        }
    }
}
