using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NukeScript : MonoBehaviour
{
    public GameObject particles;
    public bool canDmg;
    public int nukeDmg = 999;

    public List<GameObject> dmgList;

    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Destroy(rb);
        StartCoroutine(BoomBoom());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            dmgList.Add(other.gameObject);
        }
        else if (other.CompareTag("ResourceNode"))
        {
            dmgList.Add(other.gameObject);
        }
    }

    public IEnumerator BoomBoom()
    {
        yield return new WaitForSeconds(1);
        DestroyNodes();
        canDmg = true;
        GameObject newParticles = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(newParticles, 4);
        Destroy(gameObject);
    }

    public void DestroyNodes()
    {
        foreach (var gameobject in dmgList)
        {
            if (gameobject != null)
            {
                var gameobjectToDmg = gameobject.GetComponent<IDamagable>();
                gameobjectToDmg.Damagable(nukeDmg);
            }
        }
    }
}
