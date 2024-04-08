using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject player;
    private string path;
    public int autoSaveTimer = 25;
    public bool autoSaveEnabled;
    public bool playerSave;
    public int max = 100;
    void Start()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        playerData = Load();
        player = GameObject.FindGameObjectWithTag("Player");
        if (playerSave)
        {
            player.GetComponent<LoadPlayerData>().Initialize();
        }
        FindAnyObjectByType<SoundChanger>().Initialize();
        //FindAnyObjectByType<MouseSensitivityChanger>().Initialize();
        if (!playerSave)
        {
            FindAnyObjectByType<ResManerger>().Initialize();
        }
        if (autoSaveEnabled)
        {
            StartCoroutine(AutoSave());
        }
    }

    public void Save()
    {
        if (playerSave)
        {
            playerData.x = player.transform.position.x;
            playerData.y = player.transform.position.y;
            playerData.z = player.transform.position.z;
            playerData.food = player.GetComponent<PlayerManager>().food;
            playerData.mana = player.GetComponent<PlayerManager>().mana;
            playerData.health = player.GetComponent<PlayerManager>().health;
            playerData.items = FindAnyObjectByType<InventoryManager>().items.ToArray();
            playerData.mouseSensitivity = FindAnyObjectByType<CamScript>().mouseSensitivity;
        }

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(json);
        }
    }
    public PlayerData Load()
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
