using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    public Movement movementScript;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Menu"))
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
            movementScript.canILook = false;
        }
    }

    public void BackToGame()
    {
        movementScript.canILook = true;
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
}