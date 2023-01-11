using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusLevel : MonoBehaviour
{
    private Text distanceText;
    private Text highScore;
    private Text currentScore;

    private float distance;
    private int roundedDistance;
    private GameObject startPos;
    private GameObject player;
    private Player playerScript;

    private BonusLevelFinish BLF;
    private bool finish;
    private int trulyFinished = 0;

    private int playerCoins;

    private int highScoreValue;

    void Start()
    {
        startPos = GameObject.Find("Start");
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        distanceText = GameObject.Find("DistanceText").GetComponent<Text>();
        BLF = player.GetComponent<BonusLevelFinish>();

        highScore = GameObject.Find("High Score").GetComponent<Text>();
        currentScore = GameObject.Find("Current Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        finish = BLF.finish;

        if (startPos.transform.position.x < player.transform.position.x)
        {
            distance = player.transform.position.x - startPos.transform.position.x;
        }

        roundedDistance = (int)Mathf.Round(distance / 7 * 3);


        if (!finish)
        {
            distanceText.text = "" + roundedDistance;
        }
        else
        {
            // distanceText.enabled = false;
            trulyFinished += 1;
            if (trulyFinished == 1)
            {
                highScoreValue = PlayerPrefs.GetInt("distanceHighScore");

                if (roundedDistance > highScoreValue)
                {
                    PlayerPrefs.SetInt("distanceHighScore", roundedDistance);
                }

                highScoreValue = PlayerPrefs.GetInt("distanceHighScore");

                currentScore.text = "Distance: " + roundedDistance;
                highScore.text = "Best Distance: " + highScoreValue;

                playerScript.playerCoin = roundedDistance;

                // PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + roundedDistance);

                // Debug.Log(PlayerPrefs.GetInt("coins"));
            }
        }



        
        
    }
}
