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
        if (other.CompareTag("Player") == false && other.CompareTag("EnemyChecker") == false)
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") == false && collision.collider.CompareTag("EnemyChecker") == false)
        {
            if (collision.transform.GetComponent<IDamagable>() != null)
            {
                var objectToDmg = collision.transform.GetComponent<IDamagable>();
                objectToDmg.Damagable(dmg, gameObject);
                var explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);
                Destroy(explosion, 1);
                Destroy(gameObject);
            }
            else if (collision.transform.GetComponent<IDamagable>() == null)
            {
                var explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity);
                Destroy(explosion, 1);
                Destroy(gameObject);
            }
        }
    }
}