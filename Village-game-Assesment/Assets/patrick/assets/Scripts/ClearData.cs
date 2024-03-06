using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ClearData : MonoBehaviour
{
    public string path;
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
    }
}
