using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevelFinish : MonoBehaviour
{

    public bool finish = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("EndPlatform"))
        {
            finish = true;
        }
    }
}
