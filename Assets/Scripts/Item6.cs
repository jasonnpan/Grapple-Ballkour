using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item6 : MonoBehaviour
{

    Text item6;
    private int item6Purchased;
    private int skinEquipped;
    public GameObject purchase;
    public GameObject equip;
    public GameObject unequip;

    // Start is called before the first frame update
    void Start()
    {
        item6 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        item6Purchased = PlayerPrefs.GetInt("item6Purchased");
        skinEquipped = PlayerPrefs.GetInt("skinEquipped");
        item6.text = "Illusion";
    }

    public void ClickItem6()
    {
        PlayerPrefs.SetInt("purchase", 6);
        if (item6Purchased == 1 && !(skinEquipped == 4))
        {
            purchase.SetActive(false);
            equip.SetActive(true);
            unequip.SetActive(false);
        }
        if (item6Purchased == 1 && skinEquipped == 4)
        {
            purchase.SetActive(false);
            equip.SetActive(false);
            unequip.SetActive(true);

        }
        if (item6Purchased == 0)
        {
            purchase.SetActive(true);
            equip.SetActive(false);
            unequip.SetActive(false);
        }
    }

}
