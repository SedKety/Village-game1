using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private PlayerData playerData;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerData = player.GetComponent<PlayerData>();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using(StreamWriter sw = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            sw.Write(json);
        }
    }
    public void Load()
    {
        string json = string.Empty;

        using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            json = reader.ReadToEnd();
        }

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        playerData.GetComponent<PlayerData>().intsToSave = data.intsToSave;
        playerData.GetComponent<PlayerData>().floatsToSave = data.floatsToSave;
    }
}
