using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSliders : MonoBehaviour
{
    public Slider hpSlider;
    public Slider foodSlider;
    public Slider manaSlider;

    public PlayerManager playerManager;

    public void Start()
    {
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
    }
    public void Update()
    {
        hpSlider.value = playerManager.health;
        foodSlider.value = playerManager.food;
        manaSlider.value = playerManager.mana;
    }
}
