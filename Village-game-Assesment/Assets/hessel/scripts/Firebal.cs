using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebal : MonoBehaviour
{
    public int dmg;
    private void OnCollisionExit(Collision collision)
    {
        if ((collision.collider.CompareTag("ResourceNode")))
        {
            collision.gameObject.GetComponent<ResourceNodeScript>().OnDmg(dmg);
            Destroy(gameObject);
        }
        Destroy(gameObject, 5);
    }
}
