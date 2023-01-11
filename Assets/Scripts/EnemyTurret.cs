using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public GameObject player;
    public GameObject turretBulletPrefab;
    public float bulletSpeed;
    public GameObject turretBulletPosition;
    private Vector2 direction;
    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;

    public GameObject turretFacing;
    public GameObject turretHead;
    private Vector2 lookDir;
    private float lookAngle;

    public int health = 100;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        direction = player.transform.position - turretBulletPosition.transform.position;
        direction.Normalize();

        if (player.transform.position.x < transform.position.x)
        {
            lookDir = turretHead.transform.position - player.transform.position;
            lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            turretHead.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            turretFacing.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            lookDir = player.transform.position - turretHead.transform.position;
            lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            turretHead.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            turretFacing.transform.localScale = new Vector3(-1, 1, 1);

        }

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            FireBullet(direction);
        }
    }

    void FireBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(turretBulletPrefab, turretBulletPosition.transform.position, Quaternion.identity) as GameObject;
        bullet.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        //hurt animation 
        //PurpEssence.SetTrigger("onHit");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
