using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{

    public GameObject player;
    public GameObject spikeGrowBall;
    public GameObject enemySpawnEffect;

    public float rangeX;
    public float rangeY;
    private Vector2 spawnPos;

    public float spawnTimer; 
    private float spawnTimerSaver;

    // public float instantiateTimer;
    // private float instantiateTimerSaver;


    // Start is called before the first frame update
    void Start()
    {
        spawnTimerSaver = spawnTimer;
        // instantiateTimerSaver = instantiateTimer;
    }

    // Update is called once per frame
    void Update()
    {
        float posX = player.transform.position.x;
        float posY = player.transform.position.y;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {

            float spawnRangeX = Random.Range(posX - rangeX, posX + rangeX);
            float spawnRangeY = Random.Range(posY - rangeY, posY + rangeY);

            spawnPos = new Vector2(spawnRangeX, spawnRangeY);

            Instantiate(enemySpawnEffect, spawnPos, Quaternion.identity);
            spawnEnemy();


            spawnTimer = spawnTimerSaver;
        }

        // instantiateTimer -= Time.deltaTime;

        // if (instantiateTimer <= 0)
        // {
        //     spawnEnemy(spawnPos);
        //     instantiateTimer = instantiateTimerSaver;
        // }






        
    }

    void spawnEnemy()
    {

        Instantiate(spikeGrowBall, spawnPos, Quaternion.identity);

    }
}
