using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainMenuUi : MonoBehaviour
{
   
    public void LeaveGame()
    {
        Application.Quit();
    }


    public void SaveAndQuit()
    {
        FindAnyObjectByType<SaveData>().Save();
        //insert scene switch to main menu here when it gets added
    }

   
}
