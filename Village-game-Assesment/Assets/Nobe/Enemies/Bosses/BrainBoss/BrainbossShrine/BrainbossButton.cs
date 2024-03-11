using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrainbossButton : MonoBehaviour, IInteractable
{
    public TextMeshPro brainsNeededText;
    public int brainsNeeded;

    public GameObject brainboss;
    public void Iinteractable()
    {
        var inventory = FindAnyObjectByType<InventoryManager>();
        foreach(var item in inventory.GetComponent<InventoryManager>().items)
        {
            if(item.id == 6)
            {
                inventory.GetComponent<InventoryManager>().OnItemRemove(item);
                brainsNeeded--;
                brainsNeededText.text = "6/ " + brainsNeeded;
                if(brainsNeeded <= 0)
                {
                    brainboss.SetActive(true);
                }
                break;
            }
        }
    }
}
