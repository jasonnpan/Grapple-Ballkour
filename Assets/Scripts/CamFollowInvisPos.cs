using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowInvisPos : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D rb;
    public Rigidbody2D playerRB;
    // private float playerSpeed;
    public float speed = 5;
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        // playerRB = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // playerDirection = transform.position - player.transform.position;
        // rb.velocity = playerDirection * speed;

        // playerSpeed = Mathf.Abs(playerRB.velocity.x) + Mathf.Abs(playerRB.velocity.y);
        // transform.position = player.transform.position.forward;
        // this.gameObject.transform.position.x = transform.position.x + Mathf.Abs(playerRB.velocity.x) * speedFactor;
        // this.gameObject.transform.position.y = transform.position.x + Mathf.Abs(playerRB.velocity.y) * speedFactor;

        rb.velocity = new Vector3(playerRB.velocity.x * speed, playerRB.velocity.y * speed, 0);

        // transform.position = player.transform.position + player.transform.forward * speedFactor;
    }
}
