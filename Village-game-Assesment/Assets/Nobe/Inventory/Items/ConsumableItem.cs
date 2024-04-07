using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Items/Consumable")]
public class ConsumableItem : Item
{
    public int foodToReplenish;
    public int healthToHeal;


    public override void OnItemUse()
    {
        PlayerManager player = FindAnyObjectByType<PlayerManager>();

        player.health += healthToHeal;
        player.food += foodToReplenish;
    }
    public override void EditSliders(Slider healthslider, Slider foodSlider)
    {
        healthslider.value = healthToHeal;
        foodSlider.value = foodToReplenish;
    }
}
