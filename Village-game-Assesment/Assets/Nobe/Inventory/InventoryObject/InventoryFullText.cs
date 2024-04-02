using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFullText : MonoBehaviour
{
    public void Update()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(TurnTextOff());
        }

    }
    public IEnumerator TurnTextOff()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
