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

    public Slider hpSlider;
    public Slider foodSlider;
    public void Update()
    {
        if (itemToDisplay != null)
        {
            ConsumableItem consumable = itemToDisplay as ConsumableItem;

            if (consumable != null)
            {
                // If itemToDisplay is a ConsumableItem
                hpSlider.gameObject.SetActive(true);
                hpSlider.value = consumable.healthToHeal;

                foodSlider.gameObject.SetActive(true);
                foodSlider.value = consumable.foodToReplenish;
            }
            else
            {
                // If itemToDisplay is not a ConsumableItem
                hpSlider.gameObject.SetActive(false);
                foodSlider.gameObject.SetActive(false);
            }

            // Common operations for both cases
            itemPicture.texture = itemToDisplay.itemSprite.texture;
            itemPicture.gameObject.SetActive(true);
            itemName.text = itemToDisplay.itemName;
            itemDescription.text = itemToDisplay.itemDescription;
        }
        else
        {
            // If itemToDisplay is null
            itemPicture.texture = null;
            itemPicture.gameObject.SetActive(false);
            itemName.text = "Empty";
            itemDescription.text = "Select an item to view its description here";
            hpSlider.gameObject.SetActive(false);
            foodSlider.gameObject.SetActive(false);
        }
    }
}
