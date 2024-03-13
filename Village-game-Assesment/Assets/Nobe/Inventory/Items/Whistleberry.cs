using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Consumable/Whistleberry")]
public class Whistleberry : ConsumableItem
{
    public GameObject whistle;
    public override void ConsumeItem()
    {
        base.ConsumeItem();
        Instantiate(whistle);
    }
}
