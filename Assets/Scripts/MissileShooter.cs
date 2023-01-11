using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShooter : MonoBehaviour
{
    public GameObject missileProjectile;
    public Transform target;
    public float distance;
    public float range = 5;

    public float interpolationPeriod;
    private float interpolationPeriodSaver;

    public float rotationSpeed = 240;

    // Start is called before the first frame update
    void Start()
    {
        interpolationPeriodSaver = interpolationPeriod;
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(target.position, transform.position);

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        interpolationPeriod -= Time.deltaTime;

        if (interpolationPeriod < 0 && distance <= range)
        {
            //instantiate shoot effect (explosion clouds)
            //release projectile

            Instantiate(missileProjectile, transform.position, Quaternion.identity);
            interpolationPeriod = interpolationPeriodSaver;
        }
    
    }
}
