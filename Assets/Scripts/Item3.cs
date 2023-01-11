using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item3 : MonoBehaviour
{

    Text item3;
    private int item3Purchased;
    private int skinEquipped;
    public GameObject purchase;
    public GameObject equip;
    public GameObject unequip;

    // Start is called before the first frame update
    void Start()
    {
        item3 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        item3Purchased = PlayerPrefs.GetInt("item3Purchased");
        skinEquipped = PlayerPrefs.GetInt("skinEquipped");
        item3.text = "Red";
    }

    public void ClickItem3()
    {
        PlayerPrefs.SetInt("purchase", 3);

        if (item3Purchased == 1 && !(skinEquipped == 1))
        {
            purchase.SetActive(false);
            equip.SetActive(true);
            unequip.SetActive(false);
        }
        if (item3Purchased == 1 && skinEquipped == 1)
        {
            purchase.SetActive(false);
            equip.SetActive(false);
            unequip.SetActive(true);
        }
        if (item3Purchased == 0)
        {
            purchase.SetActive(true);
            equip.SetActive(false);
            unequip.SetActive(false);
        }
    }

}
