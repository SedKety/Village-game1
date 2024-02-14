using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Items inventoryItem;
    public int howManyItems;
    public bool itemInSlot;
    public RawImage itemSprite;
    public TextMeshProUGUI nameOfItem;
    public TextMeshProUGUI itemDescription;

    public GameObject slotSelectedOrNot;
    public GameObject showDescription;

    public void Update()
    {
        if(inventoryItem != null)
        {
            itemSprite.texture = inventoryItem.itemPicture.texture;
            itemInSlot = true;
            itemSprite.gameObject.SetActive(true);
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
        showDescription.SetActive(true);
        if(inventoryItem != null)
        {
            nameOfItem.text = inventoryItem.itemName;
            itemDescription.text = inventoryItem.description;
        }
    }
}
