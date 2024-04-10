using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearData : MonoBehaviour
{
    private string path;
    private string metaPath;
    private void Start()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        metaPath = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.meta";
    }
    public void Clear()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        if (File.Exists(metaPath))
        {
            File.Delete(metaPath);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
