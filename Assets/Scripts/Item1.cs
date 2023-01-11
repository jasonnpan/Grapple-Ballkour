using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item1 : MonoBehaviour
{

    Text item1;
    private int currentLevel = 0;
    private int maxLevel = 20;

    // Start is called before the first frame update
    void Start()
    {
        item1 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = PlayerPrefs.GetInt("extraHealth");
        item1.text = "Max Health (" + currentLevel + "/" + maxLevel + ")";    
    }

    public void ClickItem1()
    {
        PlayerPrefs.SetInt("purchase", 1);
    }

}
