using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    [SerializeField] Transform cameraHolder;
    private float verticalLookRotation;
    public GameObject mainMenu;
    public float mouseSensitivity;
    public bool canILook;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canILook = true;
    }

     void FixedUpdate()
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
    }
}
