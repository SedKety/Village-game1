using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { material, consumable}
[CreateAssetMenu(menuName = "Items/Material")]
public class Item : ScriptableObject
{
    public int id;
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;
    public GameObject itemPrefab;
    public ItemType type;
}
