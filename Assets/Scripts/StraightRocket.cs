using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StraightRocket : MonoBehaviour
{

    public Transform target;
    private Player playerScript;

    public float speed = 5f;

    private Vector2 direction;

    public GameObject explosionEffect;
    public GameObject explodeSound;

    private Rigidbody2D rb;

    private bool isDead;
    private float destructTimer = 2f;

    // Cinemachine Shake
    private CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    //cinemachine stuff
    public float ShakeDuration = 0.2f;         
    public float ShakeAmplitude = 5;     
    public float ShakeFrequency = 2;   

    private float ShakeElapsedTime = 0.2f;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        target = GameObject.Find("Player").GetComponent<Transform>();



        //cinemachine stuff
        VirtualCamera = GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>();
        if (VirtualCamera != null){
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }

        direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float angle = AngleBetweenTwoPoints(transform.position, target.position);
        transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle + 90));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }

    }


    void Update()
    {
        
        if (isDead)
        {
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
            destructTimer -= Time.deltaTime;

            if (destructTimer < 0)
            {
                Destroy(gameObject);
            }
        }



    }

    void OnCollisionEnter2D(Collision2D col)
    {

        ShakeElapsedTime = ShakeDuration;

        if (col.gameObject.tag.Equals("Player"))
        {
            playerScript.health -= 3;
        }

        Instantiate(explodeSound);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // GetComponent<Collider>().enabled = false;
        Destroy(GetComponent<PolygonCollider2D>());
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(rb);

        isDead = true;

    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
