using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour {

    public float speed;
    public float jumpforce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingright = true;


    private bool isgrounded;
    public Transform groundcheck;
    public float checkradius;
    public LayerMask whatisground;
    

    private int extrajumps;
    public int extrajumpvalue;

    private float jumptimecounter;
    public float jumptime;
    private bool isjump;

    public bool wallsliding;
    public Transform wallcheckpoint;
    public bool wallcheck;
    public LayerMask walllayermask;


    public GameObject Avatar1;
    public GameObject Avatar3;
    public GameObject Avatar4;

    private void Start()
    {
        extrajumps = extrajumpvalue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatisground);

        moveInput = Input.GetAxisRaw("Horizontal");

        if (isgrounded)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * speed / 2, rb.velocity.y);
        }

        

        Avatar1.transform.position = transform.position;
        Avatar3.transform.position = transform.position;
        Avatar4.transform.position = transform.position;

        if (facingright == false && moveInput > 0)
        {
            flip();
        }
        else if (facingright == true && moveInput < 0)
        {
            flip();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    private void Update()
    {
        //if (isgrounded == true)
        //{
        //    extrajumps = extrajumpvalue;
        //}

        //if (Input.GetKeyDown(KeyCode.Space) && extrajumps > 0)
        //{
        //    rb.velocity = Vector2.up * jumpforce;
        //    extrajumps--;
        //}
        //else if (Input.GetKeyDown(KeyCode.Space) && extrajumps == 0 && isgrounded == true)
        //{
        //    rb.velocity = Vector2.up * jumpforce;
        //}

        if (isgrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isjump = true;
            jumptimecounter = jumptime;
            rb.velocity = Vector2.up * jumpforce;
        }
        if (Input.GetKey(KeyCode.Space) && isjump == true && !wallsliding)
        {
            if (jumptimecounter > 0)
            {
                rb.velocity = Vector2.up * jumpforce;
                jumptimecounter -= Time.deltaTime;
            }
            else
            {
                isjump = false;
            }


        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isjump = false;
        }


        if (!isgrounded)
        {
            wallcheck = Physics2D.OverlapCircle(wallcheckpoint.position, 0.5f, walllayermask);
            
            if(facingright && (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) )&& wallcheck || !facingright && (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow)) && wallcheck)
            {
                HandleWallSliding();
            }

        }

        if(wallcheck == false || isgrounded)
        {
            wallsliding = false;
        }
    }

    void HandleWallSliding()
    {
        rb.velocity = new Vector2(rb.velocity.x, -0.90f);

        wallsliding = true;

        if (Input.GetButtonDown("Jump"))
        {
            //if (facingright)
            //{
            //    rb.velocity = new Vector2(150, 7) * jumpforce;
            //    JUMPCHECK = true;
            //}
            //else
            //{
            //    rb.velocity = new Vector2(-150, 7) * jumpforce;
            //    JUMPCHECK = true;
            //}
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isjump = true;
                jumptimecounter = jumptime;
            }
            if (Input.GetKey(KeyCode.Space) && isjump == true)
            {
                if (jumptimecounter > 0)
                {
                    rb.velocity = Vector2.up * jumpforce*10;
                    jumptimecounter -= Time.deltaTime;
                }
                else
                {
                    isjump = false;
                }


            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isjump = false;
            }
        }

    }

    public bool JUMPCHECK;

    void flip()
    {
        facingright = !facingright;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
