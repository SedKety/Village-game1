using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Items inventoryItem;
    public bool itemInSlot;
    public RawImage itemSprite;
    public TextMeshProUGUI nameOfItem;
    public TextMeshProUGUI itemDescription;

    public GameObject slotSelectedOrNot;
    public GameObject showDescription;
    public ItemPickupAndItemDrop itempickup;
    public GameObject physicalItem;

    public void Update()
    {
        if (inventoryItem != null)
        {
            itemSprite.texture = inventoryItem.itemPicture.texture;
            itemInSlot = true;
            itemSprite.gameObject.SetActive(true);
            physicalItem = inventoryItem.physicalItemObject;
            nameOfItem.text = inventoryItem.itemName;
            itemDescription.text = inventoryItem.description;
        }
        else if (inventoryItem == null)
        {
            itemSprite.gameObject.SetActive(false);
            itemInSlot = false;
            nameOfItem.text = "Empty";
            itemDescription.text = "No item in this slot, get one to see its description";
            physicalItem = null;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        slotSelectedOrNot.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        slotSelectedOrNot.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        itempickup.selectedSlot = gameObject;
        showDescription.SetActive(true);
    }
}
