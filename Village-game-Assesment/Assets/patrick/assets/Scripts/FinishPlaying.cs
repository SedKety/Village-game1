using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class FinishPlaying : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.GetComponent<VideoPlayer>().frame == 180)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
