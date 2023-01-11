using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public int health;
    public int maxHealth = 20;
    public int healthRegen = 20;
    private float healthRegenTimer;
    private int extraHealthRegen;
    private int extraHealth;

    //Equip skin
    private int skinEquipped;

    public bool levelComplete;
    private float completeTimer = 2;

    private float deathScreenTimer;

    private GameObject menuBackground;
    private GameObject deathScreen;
    private GameObject levelFinishedScreen;
    private GameObject PausePanel;

    private GameObject levelFinishedEffect1;
    private GameObject levelFinishedEffect2;

    private Grapple GrappleScript;

    public GameObject hitEffect;
    public GameObject deathEffect;
    [SerializeField] private int deathEffectCheck;

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

    // Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    //rotate
    // public float rotationSpeed = 180;

    public float timeScaleDuration = 0.01f;
    public float timeScaling = 1.2f;

    //coin
    public int playerCoin = 0;

    //sounds
    public GameObject collideSound;
    public GameObject hurtSound;

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

    private bool pauseCheck;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = 0.5f;
        
        extraHealth = PlayerPrefs.GetInt("extraHealth");
        extraHealthRegen = PlayerPrefs.GetInt("healthRegen");
        maxHealth = extraHealth + maxHealth;
        health = maxHealth;

        PausePanel = GameObject.Find("PausePanel");
        PausePanel.SetActive(false);

        deathScreen = GameObject.Find("DeathPanel");
        deathScreen.SetActive(false);

        levelFinishedScreen = GameObject.Find("LevelFinishedPanel");
        levelFinishedScreen.SetActive(false);

        menuBackground = GameObject.Find("MenuBackground");
        menuBackground.SetActive(false);

        levelFinishedEffect1 = GameObject.Find("LevelFinishedEffect1");
        levelFinishedEffect1.SetActive(false);
        levelFinishedEffect2 = GameObject.Find("LevelFinishedEffect2");
        levelFinishedEffect2.SetActive(false);

        GrappleScript = GameObject.Find("Player").GetComponent<Grapple>();


        completeTimer = 3;
        deathScreenTimer = 1;


        //cinemachine stuff
        if (VirtualCamera != null){
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }



        //skin change
        skinSelected = PlayerPrefs.GetInt("skinEquipped");
        // PlayerPrefs.SetInt("skinEquiped", 3);

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


    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // }
        // health = maxHealth;
        if (Input.GetKeyDown(KeyCode.Escape) && !(PausePanel.activeInHierarchy))
        {
            menuBackground.SetActive(true);
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PausePanel.activeInHierarchy)
        {
            PausePanel.SetActive(false);
            menuBackground.SetActive(false);
            Time.timeScale = timeScaling;
        }

        healthRegenTimer += Time.deltaTime;
        if (healthRegenTimer >= healthRegen - extraHealthRegen && health < maxHealth)
        {
            health += 1;
            healthRegenTimer = 0;
        }

        if (deathEffectCheck == 0 && !(PausePanel.activeInHierarchy))
        {
            Time.timeScale = timeScaling;
        }

        // transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (health <= 0)
        {
            deathEffectCheck += 1;

            // if (deathEffectCheck >= 1 && VirtualCamera.m_Lens.OrthographicSize > 1)
            // {
            //     VirtualCamera.m_Lens.OrthographicSize -= 0.01f;
            // }

            if (deathEffectCheck >= 1)
            {
                VirtualCamera.m_Lens.OrthographicSize -= 0.005f;
                Time.timeScale = 0.5f;
                if (timeScaleDuration <= 0)
                {
                    Time.timeScale = timeScaling;
                }
            }
            else
            {
                VirtualCamera.m_Lens.OrthographicSize = 10 + velocitySpeed * speedScaleFactor - subtractFactor;

                velocitySpeed = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y);

            }

            if (deathEffectCheck == 1)
            {
                GetComponent<Renderer>().enabled = false;
                GetComponent<LineRenderer>().enabled = false;
                GetComponent<TrailRenderer>().enabled = false; 
                // GetComponent<Collider>().enabled = false;
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                GrappleScript.enabled = false;
            }

            deathScreenTimer -= Time.deltaTime;
            if (deathScreenTimer < 0)
            {
                menuBackground.SetActive(true);
                deathScreen.SetActive(true);
            }

        }

        if (levelComplete)
        {
            completeTimer -= Time.deltaTime;
            levelFinishedEffect1.SetActive(true);
            levelFinishedEffect2.SetActive(true);
        }
        
        if (completeTimer <= 0)
        {
            menuBackground.SetActive(true);
            levelFinishedScreen.SetActive(true);
        }


        //cinemachine stuff
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
 
            if (ShakeElapsedTime > 0)
            {
                
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

               
                ShakeElapsedTime -= Time.deltaTime;
            }
            else
            {
 
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }

        //speed limit
        if (rb.velocity.x > speedLimit)
        {
            rb.velocity = new Vector2(speedLimit, rb.velocity.y);
        }
        if (rb.velocity.y > speedLimit)
        {
            rb.velocity = new Vector2(rb.velocity.x, speedLimit);
        }
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
            levelComplete = true;
        }

        if (col.gameObject.tag.Equals("Traps") && deathEffectCheck == 0)
        {
            Instantiate(hurtSound);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            ShakeElapsedTime = ShakeDuration;
        }

        if (col.gameObject.tag.Equals("Boundary"))
        {
            Instantiate(hurtSound);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            ShakeElapsedTime = ShakeDuration;
            health -= 5;
        }
    }


}
