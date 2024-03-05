using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeScript : MonoBehaviour
{
    public GameObject particles;

    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Destroy(rb);
        StartCoroutine(BoomBoom());
    }

    public IEnumerator BoomBoom()
    {
        yield return new WaitForSeconds(5);
        GameObject newParticles = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(newParticles, 4);
        Destroy(gameObject);
    }
}
