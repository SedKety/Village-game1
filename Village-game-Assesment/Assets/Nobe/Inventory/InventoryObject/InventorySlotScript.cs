using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlotScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;

    public Button removeButton;

    public DescriptionScript descriptionScript;
    public void RemoveItem()
    {
        InventoryManager.instance.OnItemRemove(item);
        Instantiate(item.itemPrefab, GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>().fireBallShotPoint.position, Quaternion.identity);  
        Destroy(gameObject);
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        descriptionScript = FindAnyObjectByType<DescriptionScript>();
        descriptionScript.itemToDisplay = item;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        descriptionScript = FindAnyObjectByType<DescriptionScript>();
        descriptionScript.itemToDisplay = null;
    }
}