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

    public bool recentlyShot;
    public Animator animator;

    private void Start()
    {
         animator = FindObjectOfType<Animator>();
    }
   public  void Fire()
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
        {
            StartCoroutine(ShootFireball());
        }
    }



    public IEnumerator ShootFireball()
    {
        if(recentlyShot == false)
        {
            animator.SetBool("Fireball", true);
            recentlyShot = true;
            yield return new WaitForSeconds(1);
            recentlyShot = false;
        }
    }

}