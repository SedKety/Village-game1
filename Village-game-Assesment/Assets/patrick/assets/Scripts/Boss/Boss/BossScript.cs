using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject hitmarker;
    public GameObject hitmarker2;
    public GameObject hitmarker3;
    public int howMany;
    public LayerMask groundcheck;
    private void Start()
    {
        StartCoroutine(Attack(gameObject.GetComponent<Collider>().bounds));
    }
    IEnumerator Attack(Bounds bounds)
    {
        howMany = Random.Range(1, 8);
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(Attack1(bounds));
        //attack 2
        for (int i = 0; i < howMany; i++) 
        {
            Instantiate(hitmarker2, new Vector3(transform.position.x, SpawnPosition(), transform.position.z), Quaternion.Euler(0, (360 / howMany * i), 0));
        }
        yield return new WaitForSeconds(Random.Range(1, 3));
        //attack 3
        int spawnInt = Random.Range(3, 5);
        for (int i = 0; i < 6; i++)
        {
            GameObject curHitmarker = Instantiate(hitmarker3, new Vector3(transform.position.x, SpawnPosition(), transform.position.z - spawnInt * i), transform.rotation);
            curHitmarker.GetComponent<Attack2>().rotateTowardsPlayer = true;
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(Attack(gameObject.GetComponent<BoxCollider>().bounds));
    }
    IEnumerator Attack1(Bounds bounds)
    {
        int randomNum = Random.Range(0, 2);
        if (randomNum == 0)
        {
            for (int i = 0; i < howMany; i++)
            {
                Vector3 loc = new Vector3(Random.Range(bounds.min.x, bounds.max.x), SpawnPosition(), Random.Range(bounds.min.z, bounds.max.z));
                Instantiate(hitmarker, loc, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(1, 3));
            }
        }
        else if (randomNum == 1)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            for (int i = 0; i < howMany; i++)
            {
                Vector3 loc = new Vector3(player.transform.position.x, SpawnPosition(), player.transform.position.z);
                Instantiate(hitmarker, loc, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(1, 3));
            }
        }
    }

    public float SpawnPosition()
    {
        RaycastHit hit;
        Vector3 spawnPoint = transform.position;
        spawnPoint.y += 10;
        if (Physics.Raycast(spawnPoint, Vector3.down, out hit, Mathf.Infinity, groundcheck))
        {

        }

        return hit.point.y;
    }
}
