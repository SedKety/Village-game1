using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject fireBall;
    public Transform schietPlek;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(fireBall, schietPlek.position, schietPlek.rotation);
        }
    }
}
