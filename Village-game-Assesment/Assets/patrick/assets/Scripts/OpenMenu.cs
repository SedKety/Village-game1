using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menu;
    public Movement movement;
    public PlayerSliders sliders;
    private void Start()
    {
        movement = FindAnyObjectByType<Movement>();
        sliders = FindAnyObjectByType<PlayerSliders>();
    }
    void Update()
    {
        if (Input.GetButton("Menu"))
        {
            sliders.gameObject.SetActive(false);
            menu.SetActive(true);
            Time.timeScale = 0f;
            movement.canILook = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
