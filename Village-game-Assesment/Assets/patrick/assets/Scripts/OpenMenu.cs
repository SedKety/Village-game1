using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menu;
    public Movement movement;

    private void Start()
    {
        movement = FindAnyObjectByType<Movement>();
    }
    void Update()
    {
        if (Input.GetButton("Menu"))
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
            movement.canILook = false;
        }
    }
}
