using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    public LayerMask groundLayerMask;
    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

    }
    public void Write(bool flip)
    {
        if (flip == true)
        {
            print("Hello world");
        }
    }
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("ground");
    }
    public bool DoRayCollisionCheck()
    {
        float rayLength = 0.1f; // length of raycast


        //cast a ray downward 
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayerMask);
        Color hitColor = Color.white;



        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
        }
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
    public bool DoRayCollisionCheck1()
    {
        float rayLength = 0.1f; // length of raycast
        Color hitColor1 = Color.green;

        //cast a ray downward 

        Vector3 rayoffset1 = new Vector3(-0.01f ,0.1f,0);
        Vector3 rayoffset2 = new Vector3(0.01f, 0.1f,0);

        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + rayoffset1, Vector2.right, rayLength, groundLayerMask);       
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + rayoffset2, Vector2.left, rayLength, groundLayerMask);
        
        

        if (( hit1.collider != null) || (hit2.collider != null ))
        {
            hitColor1 = Color.red;
            return true;
        }
        Debug.DrawRay(transform.position + rayoffset1, Vector2.left * rayLength, hitColor1 );
        Debug.DrawRay(transform.position + rayoffset2, Vector2.right * rayLength, hitColor1);
        return false;
             

        
    }
    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.1f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector2.up * rayLength, hitColor);

        return hitSomething;

    }
}
