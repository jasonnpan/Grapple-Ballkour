using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinShop : MonoBehaviour
{

    Text coins;
    private int numCoins;

    // Start is called before the first frame update
    void Start()
    {
        coins = GetComponent<Text>();  
    }

    // Update is called once per frame
    void Update()
    {
        numCoins = PlayerPrefs.GetInt("coins");
        // if (Input.GetMouseButton(0))
        // {
        //     PlayerPrefs.SetInt("coins", 2000);
        // }

        coins.text = " " + numCoins;
    }
}
