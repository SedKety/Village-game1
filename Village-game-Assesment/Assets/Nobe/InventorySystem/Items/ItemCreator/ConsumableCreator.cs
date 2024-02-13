using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemCreator/Consumable")]
public class ConsumableCreator : ScriptableObject
{
    public itemTypes typeOfItem;
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;

    public int healing;
    public int food;
}
