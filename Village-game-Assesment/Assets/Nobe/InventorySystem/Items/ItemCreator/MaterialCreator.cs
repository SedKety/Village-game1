using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemCreator/Material")]
public class ItemCreator : ScriptableObject
{
    public itemTypes typeOfItem;
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;
}
