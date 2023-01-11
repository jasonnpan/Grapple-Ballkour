using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{

    // public Animator purpleChicken;
    Rigidbody2D rb;

    private Transform pos1;
    private Transform pos2;
    private GameObject platform;

    public float speed = 2;

    void Start()
    {
        platform = gameObject.transform.Find("Platform").gameObject;

        rb = platform.GetComponent<Rigidbody2D>();
        pos1 = gameObject.transform.Find("pos1");
        pos2 = gameObject.transform.Find("pos2");
    }

    // Update is called once per frame
    void Update()
    {

        if (platform.transform.position.x < pos1.transform.position.x)
        {
            speed = Mathf.Abs(speed);
        
        }
        else if (platform.transform.position.x > pos2.transform.position.x)
        {
            speed = -Mathf.Abs(speed);
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);

    }
}
