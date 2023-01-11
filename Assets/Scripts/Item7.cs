using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item7 : MonoBehaviour
{

    Text item7;
    private int item7Purchased;
    private int skinEquipped;
    public GameObject purchase;
    public GameObject equip;
    public GameObject unequip;

    // Start is called before the first frame update
    void Start()
    {
        item7 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        item7Purchased = PlayerPrefs.GetInt("item7Purchased");
        skinEquipped = PlayerPrefs.GetInt("skinEquipped");
        item7.text = "Smiley";
    }

    public void ClickItem7()
    {
        PlayerPrefs.SetInt("purchase", 7);
        if (item7Purchased == 1 && !(skinEquipped == 5))
        {
            purchase.SetActive(false);
            equip.SetActive(true);
            unequip.SetActive(false);
        }
        if (item7Purchased == 1 && skinEquipped == 5)
        {
            purchase.SetActive(false);
            equip.SetActive(false);
            unequip.SetActive(true);

        }
        if (item7Purchased == 0)
        {
            purchase.SetActive(true);
            equip.SetActive(false);
            unequip.SetActive(false);
        }
    }

}
