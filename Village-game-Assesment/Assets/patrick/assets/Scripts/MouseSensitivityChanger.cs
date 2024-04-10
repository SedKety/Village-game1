using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseSensitivityChanger : MonoBehaviour
{
    public TMP_InputField input;
    private string currentSens;

    private void Start()
    {
        input = GetComponent<TMP_InputField>();
    }
    public void Initialize()
    {
        input.text = FindAnyObjectByType<SaveData>().playerData.mouseSensitivity.ToString();
    }
    public void ValueChanged()
    {
        if (input.text.Length > 0)
        {
            try
            {
                float sens = float.Parse(input.text);
                FindAnyObjectByType<CamScript>().mouseSensitivity = sens;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                input.text = currentSens;
            }
        }
    }
    public void OnSelect()
    {
        currentSens = input.text;
    }
}
