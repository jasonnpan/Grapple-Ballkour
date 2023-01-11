using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float laserLength = 10;
    public float laserMaxWidth = 1;
    public float widthGrowthSpeed = 0.25f;
    public float laserTimer = 1;
    public float laserDurationScaler = 0.5f;

    private float laserStartWidth;
    private float laserWidth;
    public float timer;
    private GameObject beam;

    void Start()
    {
        laserStartWidth = 0;
        laserWidth = laserStartWidth;
        beam = transform.Find("Beam").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        timer += laserDurationScaler * Time.deltaTime;

        if (laserWidth <= laserMaxWidth)
        {
            laserWidth += widthGrowthSpeed * Time.deltaTime;
            timer = 0;
            beam.transform.localScale = new Vector2(laserLength, laserWidth);
        }
        
        else if (timer <= laserTimer)
        {  
            beam.transform.localScale = new Vector2(laserLength, laserWidth * 3);
        }

        else
        {
            laserWidth = laserStartWidth;
        }

        
    }
}
