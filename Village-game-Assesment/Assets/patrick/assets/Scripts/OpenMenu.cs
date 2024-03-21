using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menu;
    public CamScript camScript;
    public PlayerSliders sliders;
    private void Start()
    {
        camScript = FindAnyObjectByType<CamScript>();
        sliders = FindAnyObjectByType<PlayerSliders>();
    }
    void Update()
    {
        if (Input.GetButton("Menu"))
        {
            sliders.gameObject.SetActive(false);
            menu.SetActive(true);
            Time.timeScale = 0f;
            camScript.canILook = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
