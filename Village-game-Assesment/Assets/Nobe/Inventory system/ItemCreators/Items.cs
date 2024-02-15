
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemCreator/Materials")]
public class Items : ScriptableObject
{
    public itemType typeOfItem;
    public string itemName;
    public string description;
    public Sprite itemPicture;
    public GameObject physicalItemObject;
}

