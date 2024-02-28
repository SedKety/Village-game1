using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionScript : MonoBehaviour
{
    public Item itemToDisplay;

    public RawImage itemPicture;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    public void Update()
    {
        if (itemToDisplay)
        {
            itemPicture.texture = itemToDisplay.itemSprite.texture;
            itemPicture.gameObject.SetActive(true);
            itemName.text = itemToDisplay.itemName;
            itemDescription.text = itemToDisplay.itemDescription;
        }
        else if(itemToDisplay == null)
        {
            itemPicture.texture = null;
            itemPicture.gameObject.SetActive(false);
            itemName.text = "Empty";
            itemDescription.text = "Select an item to view its description here";
        }
    }
}
