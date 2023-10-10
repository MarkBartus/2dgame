using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class warrior : MonoBehaviour
{
    public LayerMask groundLayer;
    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
    HelperScript helper;
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
        helper = gameObject.AddComponent<HelperScript>();


    }

    // Update is called once per frame
    void Update()
    {
        int yMovement = (int)Input.GetAxisRaw("Vertical");
        if (yMovement == 1)
        {
            Jump();
        }
        anim.SetBool("run", false);
        anim.SetBool("jump", false);
        anim.SetBool("attack1", false);
        
        float speed = 1f;
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
        
        if (Input.GetKey("f") == true)
        {
            print("player pressed f");
            anim.SetTrigger("attack1");

        }
        void Jump()
        {
            if (!IsGrounded())
            {
                return;
            }
            else
            {
                if (Input.GetKeyDown("w"))
                {
                    rb.AddForce(new Vector3(0, 2, 0), ForceMode2D.Impulse);
                    anim.SetBool("jump", true);



                }
            }
        }


    }

}

