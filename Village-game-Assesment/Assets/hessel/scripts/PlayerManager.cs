using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public float mana;
    public float maxMana;

    public float food;
    public float maxFood;

    public bool hungerEnabled;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        mana = 100;
        food = 100;
        StartCoroutine(Hunger());
        StartCoroutine(HealthRecovery());
        StartCoroutine(ManaRecovery());
    }
    private void Update()
    {
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
        if(mana >= maxMana)
        {
            mana = maxMana;
        }
        if(maxFood >= maxFood)
        {
            food = maxFood;
        }
    }

    public void DoDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            print("You Died");
        }
    }

    public IEnumerator Hunger()
    {
        while (hungerEnabled)
        {
            int canDecreaseFood = Random.Range(0, 5);
            if (canDecreaseFood == 0)
            {
                food -= 1;
                yield return new WaitForSeconds(5f);
            }
        }
    }

    public IEnumerator ManaRecovery()
    {
        if (mana <= 99)
        {
            mana += 0.5f;
            yield return new WaitForSeconds(1f);
            StartCoroutine(ManaRecovery());
        }
        else if (mana == 100)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(ManaRecovery());
        }
    }

    public IEnumerator HealthRecovery()
    {
        if (health <= 99)
        {
            health += 0.1f;
            yield return new WaitForSeconds(1f);
            StartCoroutine(HealthRecovery());
        }
        else if (health == 100)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(HealthRecovery());
        }
    }
}
