using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject finishScreen;
    public GameObject timeText;
    public void Start()
    {
        finishScreen.SetActive(true);
        timeText = FindAnyObjectByType<TimeText>().gameObject;
        timeText.GetComponent<TimeText>().FinishTime();
    }
}
