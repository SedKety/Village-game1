using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireBallSpeed = 10;
    public GameObject fireBall;
    public Transform fireBallShotPoint;

    public PlayerManager playerManager;
    void Fire()
    {
        if (playerManager.mana >= 10)
        {
            playerManager.mana -= 10;
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