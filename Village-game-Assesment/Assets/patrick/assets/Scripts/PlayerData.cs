using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    //ingame
    public float x, y, z;
    public float health, mana, food;
    public Item[] items;
    //settings
    public int resolutionIndex;
    public bool fullscreen;
    public float sound;
}
