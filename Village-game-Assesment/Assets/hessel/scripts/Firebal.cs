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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false)
        {
            if (other.transform.GetComponent<IDamagable>() != null)
            {
                var objectToDmg = other.transform.GetComponent<IDamagable>();
                objectToDmg.Damagable(dmg, gameObject);
                var explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);
                Destroy(explosion, 1);
                Destroy(gameObject);
            }
            else if (other.transform.GetComponent<IDamagable>() == null)
            {
                var explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);
                Destroy(explosion, 1);
                Destroy(gameObject);
            }
        }
    }
}
