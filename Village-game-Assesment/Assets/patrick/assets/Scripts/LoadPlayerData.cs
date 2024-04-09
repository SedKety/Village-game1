using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadPlayerData : MonoBehaviour
{
    public PlayerData playerData;
    public PlayerManager playerManager;
    private string path;
    public Item[] curItems;
    public Item[] itemIDs;
    public void Initialize()
    {
        playerData = FindAnyObjectByType<SaveData>().playerData;
        playerManager = gameObject.GetComponent<PlayerManager>();
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        if (File.Exists(path))
        {
            int i = 0;
            gameObject.transform.position = new Vector3(playerData.x, playerData.y, playerData.z);
            playerManager.health = playerData.health;
            playerManager.mana = playerData.mana;
            playerManager.food = playerData.food;
            GetComponent<CamScript>().mouseSensitivity = playerData.mouseSensitivity;
            foreach(var item in playerData.ids)
            {
                i++;
                if (item != 0)
                {
                    Item itemToAdd = itemIDs[item];
                    FindAnyObjectByType<InventoryManager>().OnItemAdd(itemToAdd);
                }
            }
            playerData.ids.Clear();
        }
        else
        {
            return;
        }
    }
}
