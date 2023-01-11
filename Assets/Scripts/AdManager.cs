using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{

    private int numCoins;

    void Start()
    {
        Advertisement.Initialize("4273342");
    }

    // Start is called before the first frame update
    public void AdReward()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Rewarded Ad not ready.");
        }

        numCoins = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 100);

    }




}
