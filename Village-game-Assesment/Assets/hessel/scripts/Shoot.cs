using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireBallSpeed = 10;
    public GameObject fireBall;
    public Transform fireBallShotPoint;

    public PlayerManager playerManager;

    public int manaCost;
    void Fire()
    {
        if (playerManager.mana >= manaCost)
        {
            playerManager.mana -= manaCost;
            Rigidbody bulletClone = Instantiate(fireBall, fireBallShotPoint.position, fireBallShotPoint.rotation).GetComponent<Rigidbody>();
            bulletClone.velocity = fireBallShotPoint.forward * fireBallSpeed;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            Fire();
    }

}