using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Material")]
public class Item : ScriptableObject
{
    public int id;
    public Sprite itemSprite;
    public string itemName;
    public GameObject itemPrefab;
}
