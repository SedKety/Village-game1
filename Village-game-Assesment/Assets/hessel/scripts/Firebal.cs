using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebal : MonoBehaviour
{
    public GameObject bal;
    public Transform plek;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(bal,plek.position,plek.rotation);
        }
    }
}
