using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{

    public bool onWater;
    public GameObject player;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player = collision.gameObject;
            StartCoroutine(DmgPlayer(player));
            onWater = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        onWater = false;
    }

    public IEnumerator DmgPlayer (GameObject player) 
    {
        player.GetComponent<PlayerManager>().DoDamage(10);
        yield return new WaitForSeconds(2.5f);
        if(onWater)
        {
            StartCoroutine (DmgPlayer(player));
        }
    }

}
