using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType { material, consumable }
public abstract class Item : ScriptableObject
{
    public int id;
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;
    public GameObject itemPrefab;
    public ItemType type;
    public abstract void OnItemUse();
    public abstract void EditSliders(Slider slider1, Slider slider2);
}
