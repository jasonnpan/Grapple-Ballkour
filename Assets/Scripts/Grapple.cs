using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    private Vector2 mousePos;
    private Vector2 grappleDirection;
    private Vector2 rayStart;
    private Vector2 growRadius;
    public LayerMask platforms;
    public LayerMask traps;
    public LayerMask missileShooter;
    public LayerMask missile;
    private SpringJoint2D springJoint;
    private LineRenderer lineRenderer;
    private RaycastHit2D hit;
    private RaycastHit2D hitTrap;
    private RaycastHit2D hitBoundary;
    private RaycastHit2D hitGrow;
    public GameObject cannotHitEffect;
    private bool ifGrapplable;
    private bool ifTrapGrapplable;

    public float grappleRange = 50f;
    public float lineDrawSpeed = 1f;

    private float x;
    private Vector2 pointA;
    private Vector2 pointB;
    private Vector2 dir;
    private Vector2 pointAlongLine;

    private Vector2 platformCenterDistance;
    
    private float counter;
    private float dist;

    private bool ifGrowingCircle;

    //sfx
    // public GameObject grappleShootSFX;

    void Start()
    {
        springJoint = GetComponent<SpringJoint2D>();
        lineRenderer = GetComponent<LineRenderer>();

        //springJoint settings
        springJoint.connectedAnchor = transform.position;
        springJoint.enableCollision = true;
        springJoint.autoConfigureDistance = false;
        springJoint.distance = 3.5f;
        springJoint.dampingRatio = 1;
        springJoint.frequency = 1;

    }
    void Update()
    {
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        grappleDirection = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        grappleDirection.Normalize();

        springJoint.enabled = false;
        lineRenderer.enabled = false;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics2D.Raycast(transform.position, grappleDirection, grappleRange))
            {
                hitBoundary = Physics2D.Raycast(transform.position, grappleDirection, grappleRange);
                
                if (hitBoundary.collider.tag == "Boundary")
                {
                    ifGrapplable = false;
                }
                
                else if (hitBoundary.collider.gameObject.layer == LayerMask.NameToLayer("Platform") || hitBoundary.collider.gameObject.layer == LayerMask.NameToLayer("MissileShooter") || hitBoundary.collider.gameObject.layer == LayerMask.NameToLayer("Missile"))
                {
                    hit = Physics2D.Raycast(transform.position, grappleDirection, grappleRange, platforms | missileShooter | missile);
                    platformCenterDistance = new Vector2(hit.point.x - hit.collider.transform.position.x, hit.point.y - hit.collider.transform.position.y);
                    counter = 0;
                    ifGrapplable = true;
                }

                else if (hitBoundary.collider.gameObject.layer == LayerMask.NameToLayer("Traps") || hitBoundary.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
                {
                    hitTrap = Physics2D.Raycast(transform.position, grappleDirection, grappleRange, traps);
                    Instantiate(cannotHitEffect, hitTrap.point, Quaternion.identity);

                    hit = Physics2D.Raycast(transform.position, grappleDirection, grappleRange, platforms | missileShooter | missile);
                    platformCenterDistance = new Vector2(hit.point.x - hit.collider.transform.position.x, hit.point.y - hit.collider.transform.position.y);
                    counter = 0;
                    ifGrapplable = true;
                }
                else
                {
                    ifGrapplable = false;
                }
            }
            else
                {
                    ifGrapplable = false;
                }

            // if (Physics2D.Raycast(transform.position, grappleDirection, grappleRange, traps))
            // {
            //     // Instantiate(grappleShootSFX);
            //     hitTrap = Physics2D.Raycast(transform.position, grappleDirection, grappleRange, traps);
            //     // counter = 0;

            //     // ifTrapGrapplable = true;
            //     ifGrapplable = false;

            //     Instantiate(cannotHitEffect, hitTrap.point, Quaternion.identity); // add delay & SFX

            //     // pointA = transform.position;
            //     // pointB = hitTrap.point;

            //     // dist = Vector2.Distance(transform.position, hitTrap.point);
            //     // dir = pointB - pointA;
            //     // dir.Normalize();
            // }

            // if (Physics2D.Raycast(transform.position, grappleDirection, grappleRange, platforms | missileShooter | missile))
            // {
            //     // Instantiate(grappleShootSFX);
            //     hit = Physics2D.Raycast(transform.position, grappleDirection, grappleRange, platforms | missileShooter | missile);
            //     platformCenterDistance = new Vector2(hit.point.x - hit.collider.transform.position.x, hit.point.y - hit.collider.transform.position.y);
            //     counter = 0;
                
            //     ifGrapplable = true;
            //     // ifTrapGrapplable = false;
            // }

            // else
            // {
            //     ifGrapplable = false;
            // }

            // if (hit.collider.tag.Equals("GrowingCircle"))
            // {
            //     Vector2 growRadius = new Vector2(hit.point.x - hit.collider.gameObject.transform.position.x, hit.point.y - hit.collider.gameObject.transform.position.y);

            //     Vector2 rayStart = new Vector2(hit.point.x + growRadius.x * 5, hit.point.y + growRadius.y * 5);

            //     ifGrowingCircle = true;
            // }
        }

        else if(Input.GetMouseButton(0) && ifGrapplable)
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag.Equals("GrowingCircle"))
                {
                    springJoint.enabled = true;
                    lineRenderer.enabled = true;
                    
                    springJoint.connectedAnchor = hit.collider.transform.position;

                    pointA = transform.position;
                    pointB = springJoint.connectedAnchor;

                    dist = Vector2.Distance(transform.position, springJoint.connectedAnchor);
                    dir = pointB - pointA;
                    dir.Normalize();
                    x = Mathf.Lerp(0, dist, counter);

                    pointAlongLine = x * dir + pointA;

                    if (counter < dist)
                    {
                        counter += .1f / lineDrawSpeed;
                    }

                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, pointAlongLine);
                }

                else
                {
                    springJoint.enabled = true;
                    lineRenderer.enabled = true;
                    
                    springJoint.connectedAnchor = new Vector2 (hit.collider.transform.position.x +platformCenterDistance.x, hit.collider.transform.position.y + platformCenterDistance.y);

                    pointA = transform.position;
                    pointB = springJoint.connectedAnchor;

                    dist = Vector2.Distance(transform.position, springJoint.connectedAnchor);
                    dir = pointB - pointA;
                    dir.Normalize();
                    x = Mathf.Lerp(0, dist, counter);

                    pointAlongLine = x * dir + pointA;

                    if (counter < dist)
                    {
                        counter += .1f / lineDrawSpeed;
                    }

                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, pointAlongLine);
                }
            }
            


            
        }

        // else if(Input.GetMouseButton(0) && ifTrapGrapplable)
        // {
        //     lineRenderer.enabled = true;

        //     x = Mathf.Lerp(0, dist, counter);

        //     pointAlongLine = x * dir + pointA;

        //     if (counter < dist)
        //     {
        //         counter += .1f / lineDrawSpeed;
        //         lineRenderer.SetPosition(0, transform.position);
        //         lineRenderer.SetPosition(1, pointAlongLine);
        //     }      
        //     else
        //     {
        //         ifTrapGrapplable = false;
        //         lineRenderer.enabled = false;
        //     }
        // }

        // else if (Input.GetMouseButton(0) && ifGrowingCircle)
        // {

        //     hitGrow = Physics2D.Raycast(rayStart, hit.collider.gameObject.transform.position);

        //     Vector2 dir = new Vector2(hit.collider.gameObject.transform.position.x - hitGrow.point.x, hit.collider.gameObject.transform.position.y - hitGrow.point.y);
        //     dir.Normalize();

        //     Debug.DrawRay(hitGrow.point, dir, Color.green, 2); 
        //     Debug.Log("1");

        //     springJoint.enabled = true;
        //     lineRenderer.enabled = true;
            
        //     springJoint.connectedAnchor = hitGrow.point;

        //     pointA = transform.position;
        //     pointB = hitGrow.point;

        //     dist = Vector2.Distance(transform.position, hitGrow.point);
        //     dir = pointB - pointA;
        //     dir.Normalize();
        //     x = Mathf.Lerp(0, dist, counter);

        //     pointAlongLine = x * dir + pointA;

        //     if (counter < dist)
        //     {
        //         counter += .1f / lineDrawSpeed;
        //     }

        //     lineRenderer.SetPosition(0, transform.position);
        //     lineRenderer.SetPosition(1, pointAlongLine);
        // }
        
    }

}
