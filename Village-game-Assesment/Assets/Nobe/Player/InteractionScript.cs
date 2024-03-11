using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public RaycastHit hit;
    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<IInteractable>() != null)
                {
                    hit.collider.GetComponent<IInteractable>().Iinteractable();
                }
            }
        }
    }
}
