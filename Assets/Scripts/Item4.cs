using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item4 : MonoBehaviour
{

    Text item4;
    private int item4Purchased;
    private int skinEquipped;
    public GameObject purchase;
    public GameObject equip;
    public GameObject unequip;

    // Start is called before the first frame update
    void Start()
    {
        item4 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        item4Purchased = PlayerPrefs.GetInt("item4Purchased");
        skinEquipped = PlayerPrefs.GetInt("skinEquipped");
        item4.text = "Rainbow";
    }

    public void ClickItem4()
    {
        PlayerPrefs.SetInt("purchase", 4);
        if (item4Purchased == 1 && !(skinEquipped == 2))
        {
            purchase.SetActive(false);
            equip.SetActive(true);
            unequip.SetActive(false);
        }
        if (item4Purchased == 1 && skinEquipped == 2)
        {
            purchase.SetActive(false);
            equip.SetActive(false);
            unequip.SetActive(true);

        }
        if (item4Purchased == 0)
        {
            purchase.SetActive(true);
            equip.SetActive(false);
            unequip.SetActive(false);
        }
    }

}
