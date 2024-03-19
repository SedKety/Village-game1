using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundChanger : MonoBehaviour
{
    public Slider slider;
    public GameObject mainMenu;
    public void Initialize()
    {
        AudioListener.volume = FindAnyObjectByType<SaveData>().playerData.sound;
        slider.value = FindAnyObjectByType<SaveData>().playerData.sound;
    }
    public void ChangeSound()
    {
        FindAnyObjectByType<SaveData>().playerData.sound = slider.value;
        AudioListener.volume = slider.value;
        Debug.Log(AudioListener.volume);
    }
}
