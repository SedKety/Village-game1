using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    //ingame
    public float x = 470, y = 80, z = 1071;
    public float health = 100, mana = 100, food = 100;
    public List<int> ids = new List<int>();
    //settings
    public int resolutionIndex;
    public bool fullscreen;
    public float sound;
    public float mouseSensitivity = 5;
}
