using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundChanger : MonoBehaviour
{
    public Slider slider;
    public GameObject backButton;
    private void Start()
    {
        slider = GetComponent<Slider>();
        Invoke("OnStart", 0.001f);
    }
    void OnStart()
    {
        AudioListener.volume = backButton.GetComponent<SaveSettings>().settingsData.volume;
        slider.value = backButton.GetComponent<SaveSettings>().settingsData.volume;
    }
    public void ChangeSound()
    {
        AudioListener.volume = slider.value;
        Debug.Log(AudioListener.volume);
    }
}
