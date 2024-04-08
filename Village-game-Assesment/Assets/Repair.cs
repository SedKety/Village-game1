using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public int neededMaterials = 1;
    public GameObject newBoat;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Material"))
        {
            if (neededMaterials == 0)
            {
                Instantiate(newBoat, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            neededMaterials--;
            Destroy(collision.gameObject);
        }
    }
}
