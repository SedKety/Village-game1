using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    public SettingsData settingsData;
    private string path;

    private void Start()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SettingsData.json";
        settingsData = Load();
    }
    public void OnClicked()
    {
        settingsData.volume = AudioListener.volume;
        string json = JsonUtility.ToJson(settingsData);
        Debug.Log(json);

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(json);
        }
    }

    SettingsData Load()
    {
        string json = string.Empty;
        SettingsData data;

        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }
            data = JsonUtility.FromJson<SettingsData>(json);
        }
        else
        {
            data = new SettingsData();
        }
        return data;
    }
}
