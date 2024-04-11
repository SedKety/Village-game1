using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossGregScript : EnemyScript
{
    public GameObject player;

    public GameObject hitmarker;
    public GameObject barrel;
    public int howManyBarrels;
    public LayerMask layermask;

    public TextMeshProUGUI hpCounter;
    public Slider hpSlider; 
    public override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(BarrelAttack());
    }
    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z));
        navMeshAgent.destination = player.transform.position;
    }

    public override void Damagable(int dmg, GameObject weaponUsed)
    {
        base.Damagable(dmg, weaponUsed);
        hpSlider.value = enemyHp;
        hpCounter.text = "hp " + enemyHp;
    }
    public IEnumerator BarrelAttack()
    {
        for (int i = 0; i < howManyBarrels; i++)
        {
            var recentlySpawnedBarrel = Instantiate(barrel, transform.position, Quaternion.identity);
            recentlySpawnedBarrel.GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 0), ForceMode.Impulse);
            Destroy(recentlySpawnedBarrel, 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
        for (int j = 0; j < howManyBarrels; j++)
        {
            RaycastHit hit;
            Vector3 vector3 = player.transform.position;
            if (Physics.Raycast(vector3, Vector3.down, out hit, Mathf.Infinity, layermask))
            {
                var spawnedObject = Instantiate(hitmarker, hit.point, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
        }
        yield return new WaitForSeconds(5);
        StartCoroutine(BarrelAttack());
    }
}
