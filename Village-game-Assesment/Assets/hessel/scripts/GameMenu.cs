using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    public Movement movementScript;
    public PlayerSliders sliders;
    public void BackToGame()
    {
        sliders.gameObject.SetActive(true);
        movementScript.canILook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
}