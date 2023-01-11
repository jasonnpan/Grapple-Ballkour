using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player playerScript;
    private Slider slider;
    private GameObject fillArea;

    private float health;
    private float maxHealth;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        slider = GetComponent<Slider>();
        fillArea = GameObject.Find("FillArea");
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = playerScript.maxHealth;
        health = playerScript.health;
        slider.value = health / maxHealth;
        
        if (slider.value == 0)
        {
            fillArea.SetActive(false);
        }
    }
}
