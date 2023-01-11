using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReset : MonoBehaviour
{
    public void resetTime()
    {
        PlayerPrefs.SetFloat("level1Time", 9999);
        PlayerPrefs.SetFloat("level2Time", 9999);
        PlayerPrefs.SetFloat("level3Time", 9999);
        PlayerPrefs.SetFloat("level4Time", 9999);
        PlayerPrefs.SetFloat("level5Time", 9999);
        PlayerPrefs.SetFloat("level6Time", 9999);
        PlayerPrefs.SetFloat("level7Time", 9999);
        PlayerPrefs.SetFloat("level8Time", 9999);
        PlayerPrefs.SetFloat("level9Time", 9999);
        PlayerPrefs.SetFloat("level10Time", 9999);
        PlayerPrefs.SetFloat("level11Time", 9999);
        PlayerPrefs.SetFloat("level12Time", 9999);
        PlayerPrefs.SetFloat("level13Time", 9999);
        PlayerPrefs.SetFloat("level14Time", 9999);
        PlayerPrefs.SetFloat("level15Time", 9999);


    }
}
