using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Consumable/Whistleberry")]
public class Whistleberry : ConsumableItem
{
    public static bool hasPlayed;
    public GameObject whistle;
    public override void OnItemUse()
    {
        base.OnItemUse();
        if (!hasPlayed)
        {
            Instantiate(whistle);
            hasPlayed = true;
        }
    }
}
