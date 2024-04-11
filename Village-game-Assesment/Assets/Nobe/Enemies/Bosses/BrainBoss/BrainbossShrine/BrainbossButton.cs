using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BrainbossButton : MonoBehaviour
{
    public TMP_Text[] neededText;
    public int[] offered;
    public int[] needed;
    public GameObject repaired;
    public GameObject old;
    public List<int> materialid = new List<int>();
    public List<int> materials = new List<int>();
    public string[] material;
    public int curIndex = 0;
    public void Button()
    {
        var inventory = FindAnyObjectByType<InventoryManager>();
        foreach(var item in inventory.GetComponent<InventoryManager>().items)
        {
            if (materialid.Contains(item.id) && materialid[curIndex] == item.id)
            {
                inventory.GetComponent<InventoryManager>().OnItemRemove(item);
                inventory.GetComponent<InventoryManager>().ListItems();
                offered[curIndex] += 1;
                neededText[curIndex].text = offered[curIndex].ToString() + "/" + needed[curIndex].ToString() + " " + material[curIndex];
                if (offered[curIndex] >= needed[curIndex])
                {
                    materials[curIndex] = 0;
                    curIndex++;
                }
                if (materials.Distinct().Count() == 1)
                {
                    Repair();
                }
                break;
            }
        }
    }

    void Repair()
    {
        repaired.SetActive(true);
        Destroy(old);
    }

    void Update()
    {

    }
}
