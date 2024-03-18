using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour
{
    public void SaveAndQuit()
    {
        FindAnyObjectByType<SaveData>().Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

   
}
