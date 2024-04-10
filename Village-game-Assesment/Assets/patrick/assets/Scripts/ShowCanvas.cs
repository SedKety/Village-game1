using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;
    public bool shownToPlayer;

    private void Update()
    {
        if (shownToPlayer)
        {
            canvas.transform.LookAt(player.transform);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            canvas.SetActive(true);
            shownToPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
            canvas.SetActive(false);
            shownToPlayer = false;
        }
    }
}
