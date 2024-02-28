using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebal : MonoBehaviour
{
    public int dmg;

    public void Start()
    {
        Destroy(gameObject, 5);
    }
    private void OnCollisionExit(Collision collision)
    {
        if ((collision.collider.CompareTag("ResourceNode")))
        {
            collision.gameObject.GetComponent<ResourceNodeScript>().OnDmg(dmg);
            Destroy(gameObject);
        }
    }
}
