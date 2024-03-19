using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class ResManerger : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private List<Resolution> resolutionList;
    private float currentRefRate;
    private int currentResolutionIndex = 0;
    public SaveData saveData;
    public string currentRes;

    void Start()
    {
        saveData = FindAnyObjectByType<SaveData>();
        resolutions = Screen.resolutions;
        resolutionList = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefRate)
            {
                resolutionList.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < resolutionList.Count; i++)
        {
            string resolutionOption = resolutionList[i].width + "x" + resolutionList[i].height + " " + resolutionList[i].refreshRate + " Hz";
            options.Add(resolutionOption);
            if (resolutionList[i].width == Screen.width && resolutionList[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Initialize()
    {
        SetResolution(saveData.playerData.resolutionIndex);
        resolutionDropdown.value = saveData.playerData.resolutionIndex;
        resolutionDropdown.RefreshShownValue();
        currentRes = Screen.currentResolution.ToString();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutionList[resolutionIndex];
        saveData.playerData.resolutionIndex = resolutionIndex;
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
