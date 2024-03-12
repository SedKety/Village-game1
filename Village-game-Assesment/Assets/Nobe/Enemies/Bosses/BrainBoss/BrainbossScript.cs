using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainbossScript : MonoBehaviour, IDamagable
{
    public int hp;

    public GameObject bloodWater;

    public List<GameObject> bossProjectiles;
    public int bossProjectilesAmount;
    public int BossProjectileCooldown;

    public Collider playerCollider;
    private Rigidbody rb;
    public void Damagable(int dmg, GameObject weaponUsed)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            OnBossDeath();
        }
    }
    public void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        playerCollider = FindObjectOfType<PlayerManager>().GetComponent<Collider>();
        OnBossSpawn();
    }

    public void OnBossSpawn()
    {
        Instantiate(bloodWater, new Vector3(91.57936f, 77.5f, 611.9f), transform.rotation);
        gameObject.SetActive(true);
        StartCoroutine(BossCooldowns());
    }

    public void OnBossDeath()
    {

    }


    void ShootBossProjectiles()
    {
        for (int i = 0; i < bossProjectilesAmount; i++)
        {
            Vector3 randomSpawnPoint = GetRandomPointInCollider(playerCollider.bounds);
            var recentlySpawnedProjectile = Instantiate(bossProjectiles[Random.Range(0, bossProjectiles.Count)], randomSpawnPoint, Random.rotation);
            recentlySpawnedProjectile.transform.position += new Vector3(0, playerCollider.transform.position.y, 0);
        }
    }

    Vector3 GetRandomPointInCollider(Bounds bounds)
    {
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);
        float setY = playerCollider.transform.position.y;
        return new Vector3(randomX, setY + 10 , randomZ);
    }



    IEnumerator BossCooldowns()
    {
        BossProjectileCooldown -= 1;
        if (BossProjectileCooldown <= 0)
        {
            BossProjectileCooldown = 4;
            ShootBossProjectiles();
        }

        yield return new WaitForSeconds(5);

        StartCoroutine(BossCooldowns());
    }
}