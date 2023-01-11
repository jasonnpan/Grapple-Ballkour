using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private Text timer;
    public float time;
    private float roundedTime;
    private bool start = false;

    private Player playerScript;
    private bool levelComplete;

    private Text finishedTimeText;
    private Text bestTimeText;

    private float bestTime;

    private string currentLevelName;

    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Text>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        currentLevelName = SceneManager.GetActiveScene().name;

        finishedTimeText = GameObject.Find("Time").GetComponent<Text>();
        bestTimeText = GameObject.Find("BestTime").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = true;
        }

        if (start && !levelComplete)
        {
            time += Time.deltaTime;
        }

        roundedTime = Mathf.Round(time * 100) / 100;
        timer.text = "" + roundedTime;

        levelComplete = playerScript.levelComplete;

        if (levelComplete)
        {
            if (currentLevelName == "Level1")
            {
                bestTime = PlayerPrefs.GetFloat("level1Time");
            }
            else if (currentLevelName == "Level2")
            {
                bestTime = PlayerPrefs.GetFloat("level2Time");
            }
            else if (currentLevelName == "Level3")
            {
                bestTime = PlayerPrefs.GetFloat("level3Time");
            }
            else if (currentLevelName == "Level4")
            {
                bestTime = PlayerPrefs.GetFloat("level4Time");
            }
            else if (currentLevelName == "Level5")
            {
                bestTime = PlayerPrefs.GetFloat("level5Time");
            }
            else if (currentLevelName == "Level6")
            {
                bestTime = PlayerPrefs.GetFloat("level6Time");
            }
            else if (currentLevelName == "Level7")
            {
                bestTime = PlayerPrefs.GetFloat("level7Time");
            }
            else if (currentLevelName == "Level8")
            {
                bestTime = PlayerPrefs.GetFloat("level8Time");
            }
            else if (currentLevelName == "Level9")
            {
                bestTime = PlayerPrefs.GetFloat("level9Time");
            }
            else if (currentLevelName == "Level10")
            {
                bestTime = PlayerPrefs.GetFloat("level10Time");
            }
            else if (currentLevelName == "Level11")
            {
                bestTime = PlayerPrefs.GetFloat("level11Time");
            }
            else if (currentLevelName == "Level12")
            {
                bestTime = PlayerPrefs.GetFloat("level12Time");
            }
            else if (currentLevelName == "Level13")
            {
                bestTime = PlayerPrefs.GetFloat("level13Time");
            }
            else if (currentLevelName == "Level14")
            {
                bestTime = PlayerPrefs.GetFloat("level14Time");
            }
            else if (currentLevelName == "Level15")
            {
                bestTime = PlayerPrefs.GetFloat("level15Time");
            }

            Time.timeScale = 0;
            finishedTimeText.text = "Time: " + roundedTime;
            bestTimeText.text = "Best Time: " + bestTime;
        }

        if (time < bestTime)
        {
            if (currentLevelName == "Level1")
            {
                PlayerPrefs.SetFloat("level1Time", roundedTime);
            }
            else if (currentLevelName == "Level2")
            {
                PlayerPrefs.SetFloat("level2Time", roundedTime);
            }
            else if (currentLevelName == "Level3")
            {
                PlayerPrefs.SetFloat("level3Time", roundedTime);
            }
            else if (currentLevelName == "Level4")
            {
                PlayerPrefs.SetFloat("level4Time", roundedTime);
            }
            else if (currentLevelName == "Level5")
            {
                PlayerPrefs.SetFloat("level5Time", roundedTime);
            }
            else if (currentLevelName == "Level6")
            {
                PlayerPrefs.SetFloat("level6Time", roundedTime);
            }
            else if (currentLevelName == "Level7")
            {
                PlayerPrefs.SetFloat("level7Time", roundedTime);
            }
            else if (currentLevelName == "Level8")
            {
                PlayerPrefs.SetFloat("level8Time", roundedTime);
            }
            else if (currentLevelName == "Level10")
            {
                PlayerPrefs.SetFloat("level10Time", roundedTime);
            }
            else if (currentLevelName == "Level11")
            {
                PlayerPrefs.SetFloat("level11Time", roundedTime);
            }
            else if (currentLevelName == "Level12")
            {
                PlayerPrefs.SetFloat("level12Time", roundedTime);
            }
            else if (currentLevelName == "Level13")
            {
                PlayerPrefs.SetFloat("level13Time", roundedTime);
            }
            else if (currentLevelName == "Level14")
            {
                PlayerPrefs.SetFloat("level14Time", roundedTime);
            }
            else if (currentLevelName == "Level15")
            {
                PlayerPrefs.SetFloat("level15Time", roundedTime);
            }
        }

        
    }
}
