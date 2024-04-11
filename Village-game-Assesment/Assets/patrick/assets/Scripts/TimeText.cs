using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text bestTimeText;
    public void FinishTime(float timeLevelLoad)
    {
        if (Time.timeSinceLevelLoad <= FindAnyObjectByType<SaveData>().bestTimes.bestTimes)
        {
            FindAnyObjectByType<SaveData>().bestTimes.bestTimes = Time.timeSinceLevelLoad;
            FindAnyObjectByType<SaveData>().Save();
        }
        bestTimeText.text = string.Format("{0:00}", FindAnyObjectByType<SaveData>().bestTimes.bestTimes.ToString()).Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ":");
        timeText.text = string.Format("{0:00.00}", timeLevelLoad).Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator,":");
    }
}
