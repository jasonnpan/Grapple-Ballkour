using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item2 : MonoBehaviour
{

    Text item2;
    private int currentLevel = 0;
    private int maxLevel = 15;

    // Start is called before the first frame update
    void Start()
    {
        item2 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = PlayerPrefs.GetInt("healthRegen");
        item2.text = "HealthRegen (" + currentLevel + "/" + maxLevel + ")";
    }

    public void ClickItem2()
    {
        PlayerPrefs.SetInt("purchase", 2);
    }

}
