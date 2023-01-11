using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item5 : MonoBehaviour
{

    Text item5;
    private int item5Purchased;
    private int skinEquipped;
    public GameObject purchase;
    public GameObject equip;
    public GameObject unequip;

    // Start is called before the first frame update
    void Start()
    {
        item5 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        item5Purchased = PlayerPrefs.GetInt("item5Purchased");
        skinEquipped = PlayerPrefs.GetInt("skinEquipped");
        item5.text = "HeatRay";
    }

    public void ClickItem5()
    {
        PlayerPrefs.SetInt("purchase", 5);
        if (item5Purchased == 1 && !(skinEquipped == 3))
        {
            purchase.SetActive(false);
            equip.SetActive(true);
            unequip.SetActive(false);
        }
        if (item5Purchased == 1 && skinEquipped == 3)
        {
            purchase.SetActive(false);
            equip.SetActive(false);
            unequip.SetActive(true);

        }
        if (item5Purchased == 0)
        {
            purchase.SetActive(true);
            equip.SetActive(false);
            unequip.SetActive(false);
        }
    }

}
