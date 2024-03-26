using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Attack2 : MonoBehaviour
{
    public bool isSkyAttack;
    public bool isPlayerTouching;
    public int amountOfDamage;
    public bool rotateTowardsPlayer;
    public void Start()
    {
        if (!isSkyAttack)
        {
            StartCoroutine(BeamAttack());
        }
        if (isSkyAttack)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>());
        }
        if (rotateTowardsPlayer)
        {
            transform.Rotate(0, 90, 0);
        }
    }
    IEnumerator BeamAttack()
    {
        yield return new WaitForSeconds(1.5f);
        if (isPlayerTouching)
        {
            FindAnyObjectByType<PlayerManager>().DoDamage(amountOfDamage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isSkyAttack) 
        {
            if (collision.gameObject.CompareTag("Hitmarker"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerTouching = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isSkyAttack)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerTouching = false;
        }
    }

    private void OnDestroy()
    {
        if (isPlayerTouching && isSkyAttack)
        {
            FindAnyObjectByType<PlayerManager>().DoDamage(amountOfDamage);
        }
    }
}
