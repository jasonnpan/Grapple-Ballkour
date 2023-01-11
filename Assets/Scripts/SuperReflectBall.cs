using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperReflectBall : MonoBehaviour
{

    public GameObject superReflectEffect;
    public GameObject superReflectSFX;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Instantiate(superReflectEffect, transform.position, Quaternion.identity);
            Instantiate(superReflectSFX);
            Destroy(gameObject);
        }
    }
}
