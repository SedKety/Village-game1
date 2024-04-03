using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float hpRecoveryAmount;

    public float mana;
    public float maxMana;
    public float manaRecoveryAmount;

    public float food;
    public float maxFood;

    public bool hungerEnabled;

    public GameObject deadScreen;
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
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        if (mana >= maxMana)
        {
            mana = maxMana;
        }
        if (food >= maxFood)
        {
            food = maxFood;
        }
    }

    public void DoDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            deadScreen.SetActive(true);
            FindAnyObjectByType<CamScript>().canILook = false;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }

    public IEnumerator Hunger()
    {
        while (hungerEnabled)
        {
            if (food >= 0)
            {
                int canDecreaseFood = Random.Range(0, 2);
                if (canDecreaseFood == 0)
                {
                    food -= 1;
                    yield return new WaitForSeconds(1f);
                }
            }
            else
            {
                health -= 1;
                yield return new WaitForSeconds(1f);
            }
        }
    }

    public IEnumerator ManaRecovery()
    {
        if (mana <= 99)
        {
            mana += manaRecoveryAmount;
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
        if (food >= 0)
        {
            if (health <= 99)
            {
                health += hpRecoveryAmount;
                yield return new WaitForSeconds(1f);
                StartCoroutine(HealthRecovery());
            }
            else if (health == 100)
            {
                yield return new WaitForSeconds(1f);
                StartCoroutine(HealthRecovery());
            }
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(HealthRecovery());
        }
    }
}
