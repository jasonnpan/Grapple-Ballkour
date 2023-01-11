using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalTimerDisplay : MonoBehaviour
{
    private float totalTime;
    private Text time;

    // Start is called before the first frame update
    void Start()
    {
        //totalTime doesnt work, need to fix
        if (PlayerPrefs.GetFloat("level1Time") != 9999 && PlayerPrefs.GetFloat("level2Time") != 9999 && PlayerPrefs.GetFloat("level3Time") != 9999 && PlayerPrefs.GetFloat("level4Time") != 9999 && PlayerPrefs.GetFloat("level5Time") != 9999 && PlayerPrefs.GetFloat("level6Time") != 9999 && PlayerPrefs.GetFloat("level7Time") != 9999 && PlayerPrefs.GetFloat("level8Time") != 9999 && PlayerPrefs.GetFloat("level10Time") != 9999 && PlayerPrefs.GetFloat("level11Time") != 9999 && PlayerPrefs.GetFloat("level12Time") != 9999 && PlayerPrefs.GetFloat("level13Time") != 9999 && PlayerPrefs.GetFloat("level14Time") != 9999 && PlayerPrefs.GetFloat("level15Time") != 9999)
        {
            PlayerPrefs.SetFloat("totalTime", PlayerPrefs.GetFloat("level1Time") + PlayerPrefs.GetFloat("level2Time") + PlayerPrefs.GetFloat("level3Time") + PlayerPrefs.GetFloat("level4Time") + PlayerPrefs.GetFloat("level5Time") + PlayerPrefs.GetFloat("level6Time") + PlayerPrefs.GetFloat("level7Time") + PlayerPrefs.GetFloat("level8Time") + PlayerPrefs.GetFloat("level10Time") + PlayerPrefs.GetFloat("level11Time") + PlayerPrefs.GetFloat("level12Time") + PlayerPrefs.GetFloat("level13Time") + PlayerPrefs.GetFloat("level14Time") + PlayerPrefs.GetFloat("level15Time"));
        }

        time = GameObject.Find("Time").GetComponent<Text>();
        time.text = "" + PlayerPrefs.GetFloat("totalTime");
    }

    public void Check()
    {
        if (!(PlayerPrefs.GetFloat("level1Time") != 9999 && PlayerPrefs.GetFloat("level2Time") != 9999 && PlayerPrefs.GetFloat("level3Time") != 9999 && PlayerPrefs.GetFloat("level4Time") != 9999 && PlayerPrefs.GetFloat("level5Time") != 9999 && PlayerPrefs.GetFloat("level6Time") != 9999 && PlayerPrefs.GetFloat("level7Time") != 9999 && PlayerPrefs.GetFloat("level8Time") != 9999 && PlayerPrefs.GetFloat("level10Time") != 9999 && PlayerPrefs.GetFloat("level11Time") != 9999 && PlayerPrefs.GetFloat("level12Time") != 9999 && PlayerPrefs.GetFloat("level13Time") != 9999 && PlayerPrefs.GetFloat("level14Time") != 9999 && PlayerPrefs.GetFloat("level15Time") != 9999))
        {
            
        }

    }
}
