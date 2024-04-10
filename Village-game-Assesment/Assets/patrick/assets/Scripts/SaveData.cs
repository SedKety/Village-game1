using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            playerData.ids.Clear();
            playerData.x = player.transform.position.x;
            playerData.y = player.transform.position.y;
            playerData.z = player.transform.position.z;
            playerData.food = player.GetComponent<PlayerManager>().food;
            playerData.mana = player.GetComponent<PlayerManager>().mana;
            playerData.health = player.GetComponent<PlayerManager>().health;
            foreach(Item item in FindAnyObjectByType<InventoryManager>().items)
            {
                int curID = item.id;
                playerData.ids.Add(curID);
            }
            playerData.mouseSensitivity = FindAnyObjectByType<CamScript>().mouseSensitivity;
        }

        string json = JsonUtility.ToJson(playerData);
        byte[] bytes = Encoding.UTF8.GetBytes(json);
        string encryptedJson = Convert.ToBase64String(bytes);
        Debug.Log(json);

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(encryptedJson);
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
            byte[] decodedBytes = Convert.FromBase64String(json);
            string decodedJson = Encoding.UTF8.GetString(decodedBytes);
            data = JsonUtility.FromJson<PlayerData>(decodedJson);
        }
        else
        {
            data = new PlayerData();
        }
        return data;
    }
    IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(autoSaveTimer);
        Save();
        Debug.Log("Autosaved");
        StartCoroutine(AutoSave());
    }
}
