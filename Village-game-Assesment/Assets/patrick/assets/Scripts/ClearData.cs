using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearData : MonoBehaviour
{
    private string path;
    private void Start()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    public void Clear()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
