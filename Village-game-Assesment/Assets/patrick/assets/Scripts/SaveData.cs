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
    public bool autoSaveEnabled;
    public bool playerSave;
    public int max = 100;
    void Awake()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        playerData = Load();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        }
        else
        {
            playerData.x = GameObject.FindGameObjectWithTag("SpawnLocation").transform.position.x;
            playerData.y = GameObject.FindGameObjectWithTag("SpawnLocation").transform.position.y;
            playerData.z = GameObject.FindGameObjectWithTag("SpawnLocation").transform.position.z;
            playerData.food = max;
            playerData.mana = max;
            playerData.health = max;
        }

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
