using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNodeSpwanerScript : MonoBehaviour
{
    public GameObject resourceNodeToSpawn;
    public Collider spawnCollider;
    public int spawnCount;
    public Transform resourceNodeManager;
    public void Start()
    {
        resourceNodeManager = GameObject.FindGameObjectWithTag("ResourceNodeManager").transform;
        GenerateResourceNodes();
        Destroy(gameObject, 0.1f);
    }

    public void GenerateResourceNodes()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomSpawnPoint = GetRandomPointInCollider(spawnCollider.bounds);
            RaycastHit hit;

            if (Physics.Raycast(randomSpawnPoint, Vector3.down, out hit, 100))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    randomSpawnPoint.y = hit.point.y;
                    GameObject spawnedNode = Instantiate(resourceNodeToSpawn, randomSpawnPoint, Quaternion.identity, resourceNodeManager);
                    spawnedNode.transform.up = hit.normal;
                }
            }
        }
    }

    Vector3 GetRandomPointInCollider(Bounds bounds)
    {
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);
        return new Vector3(randomX, bounds.center.y, randomZ);
    }
}
