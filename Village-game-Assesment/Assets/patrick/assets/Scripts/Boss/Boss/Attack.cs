using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool isTouchingAttack;
    public GameObject barrel;
    public bool isSkyAttack;
    private void Start()
    {
        if (isSkyAttack)
        {
            Instantiate(barrel, new Vector3(transform.position.x, transform.position.y + 50, transform.position.z), transform.rotation);
        }
        else
        {
            return;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouchingAttack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTouchingAttack = false;
        }
    }
    private void OnDestroy()
    {
        if (isTouchingAttack && isSkyAttack)
        {
            FindAnyObjectByType<PlayerManager>().DoDamage(barrel.GetComponent<Attack2>().amountOfDamage);
        }
    }
}
