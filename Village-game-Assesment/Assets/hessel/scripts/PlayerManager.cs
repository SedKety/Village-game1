using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health;
    public int mana;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        mana = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {

        }
    }
}
