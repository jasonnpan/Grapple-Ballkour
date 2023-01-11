using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetMissile : MonoBehaviour
{

    public Transform target;
    private Player playerScript;

    public float speed = 5f;
    public float rotateSpeed = 200f;

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
        target = GameObject.Find("SetMissileTarget").GetComponent<Transform>();



        //cinemachine stuff
        VirtualCamera = GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>();
        if (VirtualCamera != null){
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();
            
            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;

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
            playerScript.health -= 10;
        }

        Instantiate(explodeSound);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // GetComponent<Collider>().enabled = false;
        Destroy(GetComponent<PolygonCollider2D>());
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(rb);

        isDead = true;

    }
}
