using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public int explosionDmg;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<IDamagable>() != null)
        {
            other.gameObject.GetComponent<IDamagable>().Damagable(explosionDmg, gameObject);
            Debug.Log(other);
        }
    }
}
