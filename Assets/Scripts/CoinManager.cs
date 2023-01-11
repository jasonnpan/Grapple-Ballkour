using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    Text coins;
    private int currentCoin;
    private int totalCoin;
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        coins = GetComponent<Text>();
        currentCoin = PlayerPrefs.GetInt ("coins");
    }

    void Update()
    {
        totalCoin = currentCoin + player.playerCoin;
        coins.text = " " + totalCoin;
        PlayerPrefs.SetInt("coins", totalCoin);
    }
}
