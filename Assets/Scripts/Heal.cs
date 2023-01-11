using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    public int healAmount;
    private Player player;
    
    public GameObject healEffect; 
    public GameObject shatterSound;

    public float rotateAmount = 120;

    public GameObject healAura;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(healAura, transform.position, Quaternion.identity);
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateAmount * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Instantiate(shatterSound);
            Instantiate(healEffect, transform.position, Quaternion.identity);
            if (player.health < player.maxHealth && player.health > 0)
            {
                player.health = player.maxHealth;
            }
            
            Destroy(gameObject);
        }
    }
}
