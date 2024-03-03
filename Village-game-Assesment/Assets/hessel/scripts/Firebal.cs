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
        if ((collision.collider.CompareTag("ResourceNode")))
        {
            collision.gameObject.GetComponent<ResourceNodeScript>().OnDmg(dmg);
            GameObject particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            Destroy(particles, 1);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag != "Player")
        {
           GameObject particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            Destroy(particles, 1);
            Destroy(gameObject);
        }
    }
}
