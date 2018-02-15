using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GcuHealth : MonoBehaviour
{
    public float gcuHealth = 10f;
    public bool lazy; 
    public bool gameOver = false;
    public int score = 0;

    // Use this for initialization
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool lazy = EnemyScript.laziness;

        if (gameOver == true)
        {
            Application.LoadLevel("EndScene");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShipTag")
        {
            if (lazy == true)
            {
                gcuHealth -= 1.0f;
            }

            if (lazy == false)
            {
                score++;
            }
        }
    }

    void GcuFail()
    {
        if (gcuHealth <= 0f)
        {
            gameOver = true;
        }
    }
}
