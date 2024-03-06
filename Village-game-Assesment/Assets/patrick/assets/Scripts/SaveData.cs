using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject player;
    private string path;
    void Start()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        player = GameObject.FindGameObjectWithTag("Player");
        playerData = Load();
    }

    public void Save()
    {
        playerData.x = player.transform.position.x;
        playerData.y = player.transform.position.y;
        playerData.z = player.transform.position.z;
        playerData.food = player.GetComponent<PlayerManager>().food;
        playerData.mana = player.GetComponent<PlayerManager>().mana;
        playerData.health = player.GetComponent<PlayerManager>().health;
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(json);
        }
    }
    PlayerData Load()
    {
        string json = string.Empty;
        PlayerData data;

        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }
            data = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            data = new PlayerData();
        }
        return data;
    }
}
