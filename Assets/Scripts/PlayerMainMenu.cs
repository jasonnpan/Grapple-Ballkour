using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class PlayerMainMenu : MonoBehaviour
{
    [HideInInspector]
    public int health;
    public int maxHealth = 20;
    public int healthRegen = 20;
    private float healthRegenTimer;
    private int extraHealthRegen;
    private int extraHealth;

    //Equip skin
    [SerializeField] private int skinEquipped;

    private GameObject menuBackground;

    private Grapple GrappleScript;

    public Rigidbody2D rb;


    //cinemachine stuff
    public float ShakeDuration = 0.2f;         
    public float ShakeAmplitude = 5;     
    public float ShakeFrequency = 2;   

    //cam zoom based on velocity
    public float speedScaleFactor = 0.5f;
    public float subtractFactor = 0.3f;
    private float velocitySpeed;

    private float ShakeElapsedTime;


    //rotate
    // public float rotationSpeed = 180;

    public float timeScaleDuration = 0.01f;
    public float timeScaling = 1.2f;

    //coin
    public int playerCoin = 200;

    //sounds
    public GameObject collideSound;

    //speed limit
    public float speedLimit = 50;


    //skins 
    private int skinSelected = 0;
    public Sprite defaultSkin;
    public Sprite redSkin;
    public Sprite rainbowSkin;
    public Sprite heatRaySkin;
    public Sprite onionSkin;
    public Sprite smileSkin;

    // Start is called before the first frame update
    void Start()
    {
        GrappleScript = GameObject.Find("Player").GetComponent<Grapple>();



    }

    // Update is called once per frame
    void Update()
    {

        //skin change
        skinSelected = PlayerPrefs.GetInt("skinEquipped");

        if (skinSelected == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = redSkin;
        }
        else if (skinSelected == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = rainbowSkin;
        }
        else if (skinSelected == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = heatRaySkin;
        }
        else if (skinSelected == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = onionSkin;
        }
        else if (skinSelected == 5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = smileSkin;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = defaultSkin;
        }

        Time.timeScale = timeScaling;


    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Equals("Platform"))
        {
            Instantiate(collideSound);
        }

        if (col.gameObject.tag.Equals("GrowingCircle"))
        {
            Instantiate(collideSound);
        }

        if (col.gameObject.tag.Equals("EndPlatform"))
        {
            Instantiate(collideSound);
        }

    }


}
