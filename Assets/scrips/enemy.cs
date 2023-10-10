using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
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
    }
}