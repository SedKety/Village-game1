using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    public TMP_Text timeText;
    public void FinishTime()
    {
        timeText.text = string.Format("{0:00.00}", Time.timeSinceLevelLoad).Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator,":");
    }
}
