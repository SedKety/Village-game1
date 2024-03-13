using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float hor;
    private float vert;
    private Vector3 dir;
    public float speed;
    private bool onGround;
    public Rigidbody rb;
    public float jumpVelocity;
    public float mouseSensitivity;
    [SerializeField] Transform cameraHolder;
    private float verticalLookRotation;
    public GameObject mainMenu;

    public bool canILook;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        canILook = true;
    }
    void Update()
    {
        if (canILook)
        {
            Cursor.lockState = CursorLockMode.Locked;
            transform.Rotate(Input.GetAxisRaw("Mouse X") * mouseSensitivity * Vector3.up);
            verticalLookRotation -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
            cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
        }
        else if (!canILook)
        {
            Cursor.lockState = CursorLockMode.None;
        }


        //player movement
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        dir.x = hor;
        dir.z = vert;
        transform.Translate(dir * speed * Time.deltaTime);

        //jump
        if (Input.GetButton("Jump") && onGround)
        {
            rb.velocity = new Vector3(0, jumpVelocity, 0);
            onGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}