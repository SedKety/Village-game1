using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    public Movement movementScript;
    public void BackToGame()
    {
        movementScript.canILook = true;
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
}