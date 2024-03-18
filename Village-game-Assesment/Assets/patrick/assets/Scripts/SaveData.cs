using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject player;
    private string path;
    public int autoSaveTimer = 25;
    void Start()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        player = GameObject.FindGameObjectWithTag("Player");
        playerData = Load();
        StartCoroutine(AutoSave());
    }

    public void Save()
    {
        playerData.x = player.transform.position.x;
        playerData.y = player.transform.position.y;
        playerData.z = player.transform.position.z;
        playerData.food = player.GetComponent<PlayerManager>().food;
        playerData.mana = player.GetComponent<PlayerManager>().mana;
        playerData.health = player.GetComponent<PlayerManager>().health;
        playerData.items = FindAnyObjectByType<InventoryManager>().items.ToArray();
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
    IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(25);
        Save();
        Debug.Log("Autosaved");
        StartCoroutine(AutoSave());
    }
}
