using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemCreator/Container")]
public class StorageCreater : ScriptableObject
{
    public itemTypes typeOfItem;
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;

    public ScriptableObject itemInContainer;
}
