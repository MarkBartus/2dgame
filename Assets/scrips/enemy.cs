using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public LayerMask groundLayerMask;
    HelperScript helper;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }

    public GameObject warrior;
    public float speed;

    private float distance;

    Rigidbody2D rb;
    Animator anim;	// ***
    SpriteRenderer spi;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D other)
    {

    }

    void Start()

    {
        spi = GetComponent<SpriteRenderer>();
        print("start");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // ***
        spi = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {     
            anim.SetBool("running", true);
            distance = Vector2.Distance(transform.position, warrior.transform.position);
            Vector2 direction = warrior.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, warrior.transform.position, speed * Time.deltaTime);
            anim.SetBool("running", true);
        
        if( Input.GetKey("space"))
        {
            helper.FlipObject(true); // this will execute the method in HelperScript.cs
        }
        if (Input.GetKey("h"))
        {
            helper.Write(true);
        }




        float rayLength = 0.1f; // length of raycast
        Color hitColor1 = Color.green;

        //cast a ray downward 

        Vector3 rayoffset1 = new Vector3(-0.01f, 0.1f, 0);
        Vector3 rayoffset2 = new Vector3(0.01f, 0.1f, 0);

        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + rayoffset1, Vector2.right, rayLength, groundLayerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + rayoffset2, Vector2.left, rayLength, groundLayerMask);



        if ((hit1.collider != null) || (hit2.collider != null))
        {
            hitColor1 = Color.red;
            
        }
        Debug.DrawRay(transform.position + rayoffset1, Vector2.left * rayLength, hitColor1);
        Debug.DrawRay(transform.position + rayoffset2, Vector2.right * rayLength, hitColor1);

        if (hit1.collider != null)
        {
            spi.flipX = true;
        }
        if (hit2.collider != null)
        {
            spi.flipX = true;
        }
    }
    
}
