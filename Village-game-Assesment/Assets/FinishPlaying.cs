using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FinishPlaying : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject saveManager;
    private void Update()
    {
        if (gameObject.GetComponent<VideoPlayer>().frame == 180)
        {
            mainMenu.SetActive(true);
            saveManager.SetActive(true);
        }
    }
}
