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

    public Camera cam;

    private void Start()
    {
        animator = FindObjectOfType<Animator>();
        cam = Camera.main;
    }
    public void Fire()
    {
        if (playerManager.mana >= manaCost)
        {
            playerManager.mana -= manaCost;
            Rigidbody bulletClone = Instantiate(fireBall, fireBallShotPoint.position, fireBallShotPoint.rotation).GetComponent<Rigidbody>();
            bulletClone.velocity = cam.transform.forward * fireBallSpeed;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(ShootFireball());
        }
    }

    //Nobe animator
    public IEnumerator ShootFireball()
    {
        if (recentlyShot == false)
        {
            animator.SetBool("Fireball", true);
            recentlyShot = true;
            yield return new WaitForSeconds(1);
            recentlyShot = false;
        }
    }

}