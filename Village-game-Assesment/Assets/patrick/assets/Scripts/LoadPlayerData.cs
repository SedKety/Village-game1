using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadPlayerData : MonoBehaviour
{
    public PlayerData playerData;
    public PlayerManager playerManager;
    private string path;
    public Item[] items;
    void Start()
    {
        Invoke("Load", 0.001f);
    }
    void Load()
    {
        playerData = FindAnyObjectByType<SaveData>().playerData;
        playerManager = gameObject.GetComponent<PlayerManager>();
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        if (File.Exists(path))
        {
            gameObject.transform.position = new Vector3(playerData.x, playerData.y, playerData.z);
            playerManager.health = playerData.health;
            playerManager.mana = playerData.mana;
            playerManager.food = playerData.food;
            foreach(Item item in playerData.items)
            {
                FindAnyObjectByType<InventoryManager>().OnItemAdd(item);
            }
        }
        else
        {
            return;
        }
    }
}
