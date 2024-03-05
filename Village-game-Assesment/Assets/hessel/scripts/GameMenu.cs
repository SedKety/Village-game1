using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Menu"))
        {
            menu.SetActive(true);
            
        }


    }
}