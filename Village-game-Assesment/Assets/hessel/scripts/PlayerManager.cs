using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Healh")]
    public float health;
    public float maxHealth;
    public float hpRecoveryAmount;
    [Header("Mana")]
    public float mana;
    public float maxMana;
    public float manaRecoveryAmount;
    [Header("Food")]
    public float food;
    public float maxFood;
    public float foodDropAmount;
    [Header("Dead")]
    public GameObject deadScreen;

    void Start()
    {

        health = 100;
        mana = 100;
        food = 100;

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
        HealthRegeneration();
        ManaRegeneration();
        FoodRegeneration();
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
    public void HealthRegeneration()
    {
        if (food >= 0)
        {
            if (health <= 99)
            {
                health += hpRecoveryAmount * Time.deltaTime;
            }
            else
            {
                health = maxHealth;
            }

        }
    }
    public void ManaRegeneration()
    {
        if (mana <= 99)
        {
            mana += manaRecoveryAmount * Time.deltaTime;
        }
        else
        {
            mana = maxMana;
        }
    }
    public void FoodRegeneration()
    {
        if (food >= 0)
        {
            int canDecreaseFood = Random.Range(0, 2);
            if (canDecreaseFood == 0)
            {
                food -= foodDropAmount * Time.deltaTime;
            }
        }
        else
        {
            health -= 1 * Time.deltaTime;
        }
        if (food == 100)
        {
            food = maxFood;
        }
    }

}