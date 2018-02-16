using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;

    public GameObject PlayerBullet;
    public GameObject bulletPosition;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //fire bullets when spacebar is pressed
        if (Input.GetKeyDown("space"))
        {
            //instantiate bullet
            GameObject bullet = (GameObject)Instantiate(PlayerBullet);
            bullet.transform.position = bulletPosition.transform.position; //set bullet initial pos

        }

        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else if (!Input.anyKey)
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }

    //collision:
    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();
            Destroy(gameObject); //destroy player's ship
        }
    }

    // instantiate explosion
    void PlayExplosion()
    {
        GameObject boom = (GameObject)Instantiate(explosion);

        //set position of explosion
        boom.transform.position = transform.position;
    }*/
}
