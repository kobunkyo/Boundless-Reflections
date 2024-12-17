using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    Rigidbody2D rb;
    float speed = 3f;
    float horizontalInput;
    bool lookRight = false;
    Animator playerAnim;

    public bool isEvent = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isEvent) 
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            Movement();
            Flip();
        }
        else
        {
            rb.velocity = Vector3.zero;
            playerAnim.SetBool("Walk", false);
        }
    }

    private void Movement()
    {
        rb.velocity = new Vector2(horizontalInput * speed, 0f);
        if(horizontalInput != 0)
        {
            playerAnim.SetBool("Walk", true);
        }
        else
        {
            playerAnim.SetBool("Walk", false);
        }
    }

    private void Flip()
    {
        if((lookRight && horizontalInput < 0) || (!lookRight && horizontalInput > 0))
        {
            Vector2 scale = gameObject.transform.localScale;
            scale.x *= -1;
            gameObject.transform.localScale = scale;
            lookRight = !lookRight;

        }
    }
}
