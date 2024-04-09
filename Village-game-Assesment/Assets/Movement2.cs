using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;

    [Header("Ground Check")]
    public bool onGround;
    public Transform orientation;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private Rigidbody rb;

    //Nobe: voor animaties.
    public Animator animator;
    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //Nobe
        animator = GetComponent<Animator>(); 
    }
    private void Update()
    {
        MyInput();
        SpeedControl();

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 1000f * Time.deltaTime, ForceMode.Force);

        if (onGround)
        {
            rb.drag = groundDrag;
        }
    }

    private void MyInput()
    {
        //Nobe: voor animaties
        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButton("Jump") && onGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}
