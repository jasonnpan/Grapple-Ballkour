using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCircle : MonoBehaviour
{

    public float rotationSpeed;

    private Player playerScript;

    public GameObject hurtSound;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);

        playerScript = GameObject.Find("Player").GetComponent<Player>();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Instantiate(hurtSound);
            playerScript.health -= 5;
        }
    }
}
