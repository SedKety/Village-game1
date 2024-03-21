using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    public CamScript camScript;
    public PlayerSliders sliders;

    private void Start()
    {
        camScript = FindAnyObjectByType<CamScript>(); 
    }
    public void BackToGame()
    {
        sliders.gameObject.SetActive(true);
        camScript.canILook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
}