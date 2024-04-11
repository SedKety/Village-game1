using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class FinishGame : MonoBehaviour
{
    public GameObject finishScreen;
    public GameObject timeText;
    public GameObject bestTimeText;
    public void Start()
    {
        Time.timeScale = 0f;
        finishScreen.SetActive(true);
        timeText = FindAnyObjectByType<TimeText>().gameObject;
        timeText.GetComponent<TimeText>().FinishTime(Time.timeSinceLevelLoad);

    }
}

