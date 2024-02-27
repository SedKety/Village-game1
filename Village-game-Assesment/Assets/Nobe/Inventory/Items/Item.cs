using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Consumable")]
public class Consumable : Item
{
    public int foodToReplenish;
    public int healthToHeal;
}
