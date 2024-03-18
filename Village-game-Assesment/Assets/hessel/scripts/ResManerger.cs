using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class ResolutionScript : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    public GameObject backButton;
    private Resolution[] resolutions;
    private List<Resolution> resolutionList;
    private float currentRefRate;
    private int currentResolutionIndex = 0;

    void Start()
    {
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

        Invoke("AnotherDelay", 0.001f);
    }
    //unity will niet stoppen met erroren omdat hij probeert de save te veranderen voordat hij gemaakt wordt vgm en dit is een manier om te fixen
    //wel heel kut maar tja
    void AnotherDelay()
    {
        SetResolution(FindAnyObjectByType<SaveSettings>().settingsData.resolutionIndex);
    }
    void Delay(int resolutionIndex)
    {
        FindAnyObjectByType<SaveSettings>().settingsData.resolutionIndex = resolutionIndex;
    }

    public void SetResolution(int resolutionIndex)
    {
        StartCoroutine(enumerator(resolutionIndex));
        Resolution resolution = resolutionList[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    IEnumerator enumerator(int resolutionIndex)
    {
        yield return new WaitForSeconds(0.001f);
        Delay(resolutionIndex);
    }

}
