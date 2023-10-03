using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class warrior : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;	// ***
    SpriteRenderer spi;
    

    // Start is called before the first frame update
    void Start()
    {
        print("start");
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // ***
        spi = GetComponent<SpriteRenderer>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("run", false);
        anim.SetBool("jump", false);
        anim.SetBool("attack1", false);
        
        float speed = 3f;
        if (Input.GetKey("q") == true)
        {
            print("player pressed q");
            speed = speed + 3f;
        }
        if (Input.GetKey("e") == true)
        {
            print("player pressed e");
            speed = speed - 1.5f;
        }

        if (Input.GetKey("s") == true)
        {
            print("player pressed s");
            transform.position = new Vector2(transform.position.x, transform.position.y +
            (-speed * Time.deltaTime));


        }
        if (Input.GetKey("d") == true)
        {
            print("player pressed d");
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime) , transform.position.y);
            anim.SetBool("run", true);
            spi.flipX = false;

        }
        if (Input.GetKey("a") == true)
        {
            print("player pressed a");
            transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
            anim.SetBool("run", true);
            spi.flipX = true;
        }
        if(Input.GetKeyDown("w"))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
            
            

        }
        if (Input.GetKey("f") == true)
        {
            print("player pressed f");
            anim.SetTrigger("attack1");

        }



    }
}
