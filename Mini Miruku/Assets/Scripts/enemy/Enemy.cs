using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    private float waittime;
    public float startwaittime;

    public Transform[] movespots;
    private int randomspot;

    public int health;
    private Animator anim;


    private void Start()
    {
        waittime = startwaittime;
        randomspot = Random.Range(0, movespots.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movespots[randomspot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movespots[randomspot].position) < 0.2F)
        {
            if(waittime <= 0)
            {
                randomspot = Random.Range(0, movespots.Length);
                waittime = startwaittime;
            }
            else
            {
                waittime -= Time.deltaTime;
            }
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takedamage(int damage)
    {
        health -= damage;
        Debug.Log("took dmg");
    }
}
