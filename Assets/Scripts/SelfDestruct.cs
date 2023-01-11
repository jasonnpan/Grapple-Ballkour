using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    private float destructionTimer = 5f;


    // Update is called once per frame
    void Update()
    {
        destructionTimer -= Time.deltaTime;
        if (destructionTimer < 0)
        {
            Destroy(gameObject);
        }
    }
}
