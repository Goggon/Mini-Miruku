﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

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


    public GameObject avatar1, avatar2;

    int currentavatar = 1;


    private void Start()
    {
        extrajumps = extrajumpvalue;
        rb = GetComponent<Rigidbody2D>();

        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatisground);



        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingright == false && moveInput > 0)
        {
            flip();
        }
        else if (facingright == true && moveInput < 0)
        {
            flip();
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
        if (Input.GetKey(KeyCode.Space) && isjump == true)
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

        if (Input.GetKeyDown(KeyCode.G))
        {
            switch (currentavatar)
            {
                case 1:
                    currentavatar = 2;
                    avatar1.gameObject.SetActive(false);
                    avatar2.gameObject.SetActive(true);
                    break;

                case 2:
                    currentavatar = 1;
                    avatar1.gameObject.SetActive(true);
                    avatar2.gameObject.SetActive(false);
                    break;

            }
        }
    }

    void flip()
    {
        facingright = !facingright;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
