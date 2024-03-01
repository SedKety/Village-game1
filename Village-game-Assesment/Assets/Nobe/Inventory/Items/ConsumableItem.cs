using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Consumable")]
public class ConsumableItem : Item
{
    public int foodToReplenish;
    public int healthToHeal;


    public void ConsumeItem()
    {
        PlayerManager player = FindAnyObjectByType<PlayerManager>();
        InventoryManager inventory = FindAnyObjectByType<InventoryManager>();

        player.health += healthToHeal;
        player.food += foodToReplenish;
    }
}
