using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebal : MonoBehaviour
{
    public int dmg;
    public GameObject explosionParticles;
    public void Start()
    {
        Destroy(gameObject, 5);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<IDamagable>() != null)
        {
            var objectToDmg = collision.transform.GetComponent<IDamagable>();
            objectToDmg.Damagable(dmg);
            Destroy(gameObject);
        }
    }
}
