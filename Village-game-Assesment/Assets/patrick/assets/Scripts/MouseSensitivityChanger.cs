using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseSensitivityChanger : MonoBehaviour
{
    public TMP_InputField input;

    private void Start()
    {
        input = GetComponent<TMP_InputField>();
    }
    public void ValueChanged()
    {
        if (input.text.Length > 0)
        {
            float sens = float.Parse(input.text);
            FindAnyObjectByType<CamScript>().mouseSensitivity = sens;
        }
    }
}
